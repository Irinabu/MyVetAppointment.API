using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Business.Models.Appointment;

public class AppointmentRequest
{
    public DateTime DateTime { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public AppointmentStatus Status { get; set; }
}