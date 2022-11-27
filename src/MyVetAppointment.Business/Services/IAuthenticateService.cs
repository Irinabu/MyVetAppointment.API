using MyVetAppointment.Business.Models.User;

namespace MyVetAppointment.Business.Services;

public interface IAuthenticateService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task<RegisterResponse> RegisterCustomerAsync(RegisterRequest registerRequest);
    Task<RegisterResponse> RegisterVetDoctorAsync(RegisterRequest registerRequest);
}