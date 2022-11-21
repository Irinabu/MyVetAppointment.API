using System.Security.Cryptography;
using Microsoft.Identity.Client;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace MyVetAppointment.Business.Services.Implementations;

public class AuthenticateService:IAuthenticateService
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IVetDoctorRepository _vetDoctorRepository;

    public AuthenticateService(IUserRepository userRepository, ICustomerRepository customerRepository, IVetDoctorRepository vetDoctorRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
        _vetDoctorRepository = vetDoctorRepository;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var user =await _userRepository.GetFirstAsync(x => x.Email == loginRequest.Email);
        if(user == null)
            throw new Exception("Email or password is incorrect");
        var hashedGivenPassword = HashPassword(loginRequest.Password);
        if (user.Password != hashedGivenPassword)
            throw new Exception("Email or password is incorrect");
        return new LoginResponse
        {
            Email = user.Email,
            Role = "role",
            FirstName = "sa",
            LastName = "l",
            Token = "tokem"
        };
    }

    public async Task RegisterCustomerAsync(RegisterRequest registerRequest)
    {
        var hashedPassword = await CheckUser(registerRequest);

        var user = new Customer
        {
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Password = hashedPassword
        };

        await _customerRepository.AddAsync(user);
    }

    public async Task RegisterVetDoctorAsync(RegisterRequest registerRequest)
    {
        var hashedPassword=await CheckUser(registerRequest);
        
        var user = new VetDoctor
        {
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Password = hashedPassword
        };

        await _vetDoctorRepository.AddAsync(user);
    }

    private async Task<string> CheckUser(RegisterRequest registerRequest)
    {
        // var isAlreadyRegistered = await _userRepository.GetFirstAsync(x => x.Email == registerRequest.Email);
        // if (isAlreadyRegistered != null)
        // {
        //     throw new Exception("Email already registered");
        // }
        var hashedPassword = HashPassword(registerRequest.Password);

        return hashedPassword;
    }
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
    
}