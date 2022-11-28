using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Business.Models.Appointment
{
    public class AppointmentResponse
    {
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string AppointmentStatus { get; set; }
        public string VetDoctor { get; set; }
    }
}
