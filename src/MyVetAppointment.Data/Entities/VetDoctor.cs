namespace MyVetAppointment.Data.Entities;

public class VetDoctor : User
{
    public ICollection<CustomerVetDoctor> Customers { get; set; }
    public ICollection<Appointment> Appointments { get; set; }

}