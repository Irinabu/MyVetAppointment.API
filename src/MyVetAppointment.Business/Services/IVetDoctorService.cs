using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services
{
    public interface IVetDoctorService
    {
        VetDoctor GetVetDoctorByEmailAsync(string email);
        bool UpdateVetDoctorAsync(string id, UpdateRequest model);
        bool DeleteVetDoctor(string id);

        List<VetDoctor> GetAllAsync();
    }
}
