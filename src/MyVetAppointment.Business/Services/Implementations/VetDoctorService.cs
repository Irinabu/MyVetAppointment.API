using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Business.Services.Implementations;

public class VetDoctorService : IVetDoctorService
{
    private readonly IVetDoctorRepository _vetDoctorRepository;

    public VetDoctorService(IVetDoctorRepository vetDoctorRepository)
    {
        _vetDoctorRepository = vetDoctorRepository;
    }

    public bool DeleteVetDoctor(string id)
    {
        var user = _vetDoctorRepository.GetFirstAsync(u => u.Id == Guid.Parse(id));
        if (user == null)
            return false;
        _vetDoctorRepository.DeleteAsync(user.Result);
        _vetDoctorRepository.SaveChangesAsync();
        return true;
    }

    public List<VetDoctor> GetAllAsync()
    {
        return _vetDoctorRepository.GetAllAsync(exp => true).Result;
    }


    public VetDoctor GetVetDoctorByEmailAsync(string email)
    {
        return _vetDoctorRepository.GetFirstAsync(u => u.Email == email).Result;
    }

}