using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MyVetAppointment.Business.MappingProfiles
{
    public class AppointmentMappingProfiles : Profile
    {
        public AppointmentMappingProfiles()
        {
            CreateMap<Data.Entities.Appointment, Models.Appointment.AppointmentResponse>();
            CreateMap<Models.Appointment.AppointmentRequest, Data.Entities.Appointment>();

        }

    }
}
