using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services;

public interface IAppointmentService
{
    public Task<List<AppointmentResponse>?> GetUserAppointments(User user);
    public Task<AppointmentResponse> AddAppointment(AppointmentRequest appointment, User user);
    public Task<AppointmentResponse> UpdateAppointment(AppointmentRequest appointment, Guid id, User user);
    public Task<AppointmentResponse> DeleteAppointment(Guid id);
}