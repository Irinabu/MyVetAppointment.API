using MyVetAppointment.Business.Models.User;

namespace MyVetAppointment.Business.Services;

public interface IAuthenticateService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task RegisterCustomerAsync(RegisterRequest registerRequest);
    Task RegisterVetDoctorAsync(RegisterRequest registerRequest);
}