using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Business.Services.Implementations
{
    public class VetDoctorService : IVetDoctorService
    {
        private readonly IVetDoctorRepository _vetDoctorRepository;

        public VetDoctorService(IVetDoctorRepository vetDoctorRepository)
        {
            _vetDoctorRepository = vetDoctorRepository;
        }

        public bool DeleteVetDoctor(string id)
        {
            var user = _vetDoctorRepository.Get(id);
            if (user == null)
                return false;
            _vetDoctorRepository.Remove(user);
            _vetDoctorRepository.SaveChanges();
            return true;
        }

        public IEnumerable<User> GetAllVetDoctorsAsync()
        {
            return _vetDoctorRepository.GetAll();
        }
    }
}
