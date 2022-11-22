using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services
{
    public interface IVetDoctorService
    {
        IEnumerable<User> GetAllVetDoctorsAsync();
        bool DeleteVetDoctor(string id);
    }
}
