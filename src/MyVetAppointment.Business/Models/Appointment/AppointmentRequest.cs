using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Business.Models.Appointment
{
    public class AppointmentRequest
    {
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public String EmailDoctor { get; set; }
    }
}
