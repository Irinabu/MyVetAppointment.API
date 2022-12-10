using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Data.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public Customer? Customer { get; set; }
    public VetDoctor? VetDoctor { get; set; }

    public Bill? Bill { get; set; }
}