using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Models.Appointment
{

    public class AppointmentResponse
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AppointmentStatus { get; set; }
        public VetDoctorResponse? VetDoctor { get; set; }
        public CustomerResponse? Customer { get; set; }
        public BillResponse? Bill { get; set; }
    }
}