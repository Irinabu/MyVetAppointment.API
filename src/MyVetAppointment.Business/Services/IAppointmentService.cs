using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services
{
    public interface IAppointmentService
    {
        public Task<List<AppointmentResponse>> GetUserAppointments(User user);
    }
}