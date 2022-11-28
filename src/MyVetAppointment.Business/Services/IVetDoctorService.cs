using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services
{
    public interface IVetDoctorService
    {
        IEnumerable<User> GetAllVetDoctorsAsync();
        User GetVetDoctorByEmailAsync(string email);
        bool DeleteVetDoctor(string id);
    }
}
