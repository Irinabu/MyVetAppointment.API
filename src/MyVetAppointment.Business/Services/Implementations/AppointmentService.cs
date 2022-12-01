using AutoMapper;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Enums;
using MyVetAppointment.Data.Repositories.Implementations;

namespace MyVetAppointment.Business.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVetDoctorRepository _vetRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IVetDoctorRepository userRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _vetRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentResponse>> GetUserAppointments(User user)
        {
            var type = user.GetType().ToString().Split(".");
            var role = type[type.Length - 1];

            if (role == "Customer")
            {
                var appointments = _appointmentRepository.GetAllLazyLoad(x => x.Customer.Id == user.Id, x => x.VetDoctor, x => x.Customer);
                return _mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments.ToList());
            }
            else if (role == "VetDoctor")
            {
                var appointments = _appointmentRepository.GetAllLazyLoad(x => x.VetDoctor.Id == user.Id, x => x.VetDoctor, x => x.Customer);
                return _mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments.ToList());

            }

            return null;
        }

        public async Task<AppointmentResponse> AddAppointment(AppointmentRequest appointment, User user)
        {
            var appointmentEntity = _mapper.Map<AppointmentRequest, Appointment>(appointment);
            var vetDoctor = _vetRepository.GetFirstAsync(x => x.FirstName.Equals(appointment.FirstName) && x.LastName.Equals(appointment.LastName));
            appointmentEntity.Customer = (Customer)user;
            appointmentEntity.VetDoctor = vetDoctor.Result;
            appointmentEntity.AppointmentStatus = AppointmentStatus.Pending;
            return _mapper.Map<Appointment, AppointmentResponse>(_appointmentRepository.AddAsync(appointmentEntity).Result);

        }

    }
}
