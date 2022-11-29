using AutoMapper;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAppointmentRepository _userRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IAppointmentRepository userRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentResponse>> GetUserAppointments(User user)
        {
            var type = user.GetType().ToString().Split(".");
            var role = type[type.Length - 1];

            if (role == "Customer")
            {
                var appointments = _appointmentRepository.GetAllAsync(x => x.Customer.Id == user.Id);
                return _mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments.Result);
            }
            else if (role == "VetDoctor")
            {
                var appointments = _appointmentRepository.GetAllAsync(x => x.VetDoctor.Id == user.Id);
                return _mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments.Result);
                
            }

            return null;
        }

    }
}
