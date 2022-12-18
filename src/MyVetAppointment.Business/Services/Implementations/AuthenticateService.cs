using System;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Exceptions;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Business.Services.Implementations
{

    public class AuthenticateService : IAuthenticateService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IVetDoctorRepository _vetDoctorRepository;

        public AuthenticateService(ICustomerRepository customerRepository, IVetDoctorRepository vetDoctorRepository,
            JwtService jwtService, IUserRepository userRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _vetDoctorRepository = vetDoctorRepository;
            _jwtService = jwtService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetFirstAsync(x => x.Email == loginRequest.Email);
            if (user == null)
                throw new BadRequestException("Email or password is incorrect");
            if (loginRequest.Password != null)
            {
                var hashedGivenPassword = HashPassword(loginRequest.Password);
                if (user.Password != hashedGivenPassword)
                    throw new BadRequestException("Email or password is incorrect");
            }


            var type = user.GetType().ToString().Split(".");
            var role = type[type.Length - 1];
            var jwt = _jwtService.GenerateJwt(loginRequest, role);

            return new LoginResponse
            {
                Email = user.Email,
                Role = role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = jwt
            };
        }

        public async Task<RegisterResponse> RegisterCustomerAsync(RegisterRequest registerRequest)
        {
            var hashedPassword = await CheckUser(registerRequest);

            var customer = _mapper.Map<Customer>(registerRequest);
            customer.Password = hashedPassword;

            await _customerRepository.AddAsync(customer);
            return new RegisterResponse
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Role = "Customer"
            };
        }

        public async Task<RegisterResponse> RegisterVetDoctorAsync(RegisterRequest registerRequest)
        {
            var hashedPassword = await CheckUser(registerRequest);

            var vetDoctor = _mapper.Map<VetDoctor>(registerRequest);
            vetDoctor.Password = hashedPassword;

            await _vetDoctorRepository.AddAsync(vetDoctor);
            return new RegisterResponse
            {
                Email = vetDoctor.Email,
                FirstName = vetDoctor.FirstName,
                LastName = vetDoctor.LastName,
                Role = "VetDoctor"
            };
        }

        private async Task<string?> CheckUser(RegisterRequest registerRequest)
        {
            var isAlreadyRegistered = await _userRepository.GetFirstAsync(x => x.Email == registerRequest.Email);
            if (isAlreadyRegistered != null) throw new BadRequestException("Email already registered");

            if (registerRequest.Password != null)
            {
                var hashedPassword = HashPassword(registerRequest.Password);
                return hashedPassword;
            }

            return null;
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}