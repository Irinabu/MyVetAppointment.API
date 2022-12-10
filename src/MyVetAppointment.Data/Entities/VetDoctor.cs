namespace MyVetAppointment.Data.Entities;

public class VetDoctor : User
{
    public ICollection<Appointment>? Appointments { get; set; }
}