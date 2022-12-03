using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Business.Models.Appointment
{
    public class AppointmentRequest
    {
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
