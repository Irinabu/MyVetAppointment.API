namespace MyVetAppointment.Data.Entities;

public class CustomerVetDoctor
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid VetDoctorId { get; set; }
    public VetDoctor VetDoctor{ get; set; }
}