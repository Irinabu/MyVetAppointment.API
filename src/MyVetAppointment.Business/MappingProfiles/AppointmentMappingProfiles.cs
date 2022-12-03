using AutoMapper;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.MappingProfiles;

public class AppointmentMappingProfiles : Profile
{
    public AppointmentMappingProfiles()
    {
        CreateMap<Appointment, AppointmentResponse>();
        CreateMap<AppointmentRequest, Appointment>();
    }
}