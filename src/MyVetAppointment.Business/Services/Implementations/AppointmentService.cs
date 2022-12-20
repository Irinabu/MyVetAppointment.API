using AutoMapper;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Enums;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Business.Services.Implementations
{

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IVetDoctorRepository _vetRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IVetDoctorRepository userRepository,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _vetRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentResponse>?> GetUserAppointments(User user)
        {
            var type = user.GetType().ToString().Split(".");
            var role = type[type.Length - 1];
            if (role == "Customer")
            {
                var appointments =
                    await _appointmentRepository.GetAllLazyLoad(x => x.Customer!.Id == user.Id, x => x.VetDoctor!,
                        x => x.Customer!, x => x.Bill!, x => x.Bill!.PrescriptionDrugs!);
                return _mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments.ToList());
            }

            if (role == "VetDoctor")
            {
                var appointments = await _appointmentRepository.GetAllLazyLoad(x => x.VetDoctor!.Id == user.Id,
                    x => x.VetDoctor!, x => x.Customer!, x => x.Bill!, x => x.Bill!.PrescriptionDrugs!);
                return _mapper.Map<List<Appointment>, List<AppointmentResponse>>(appointments.ToList());
            }

            return null;
        }

        public async Task<AppointmentResponse> AddAppointment(AppointmentRequest appointment, User user)
        {
            var appointmentEntity = _mapper.Map<AppointmentRequest, Appointment>(appointment);
            var vetDoctor = await _vetRepository.GetFirstAsync(x =>
                x.FirstName!.Equals(appointment.FirstName) && x.LastName!.Equals(appointment.LastName));
            appointmentEntity.Customer = (Customer)user;
            appointmentEntity.VetDoctor = vetDoctor;
            appointmentEntity.AppointmentStatus = AppointmentStatus.Pending;
            return _mapper.Map<Appointment, AppointmentResponse>(
                await _appointmentRepository.AddAsync(appointmentEntity));
        }

        public async Task<AppointmentResponse> UpdateAppointment(AppointmentRequest appointment, Guid id, User user)
        {
            var appointmentEntity =
                await _appointmentRepository.GetFirstLazyLoad(x => x.Id == id, x => x.VetDoctor!, x => x.Customer!);
            appointmentEntity!.AppointmentStatus = appointment.Status;
            appointmentEntity.Description = appointment.Description;
            appointmentEntity.Title = appointment.Title;
            appointmentEntity.DateTime = appointment.DateTime;

            return _mapper.Map<Appointment, AppointmentResponse>(
                await _appointmentRepository.UpdateAsync(appointmentEntity));
        }

        public async Task<AppointmentResponse> DeleteAppointment(Guid id)
        {
            var appointmentEntity =
                await _appointmentRepository.GetFirstLazyLoad(x => x.Id == id, x => x.VetDoctor!, x => x.Customer!);
            return _mapper.Map<Appointment, AppointmentResponse>(
                await _appointmentRepository.DeleteAsync(appointmentEntity!));
        }
    }
}