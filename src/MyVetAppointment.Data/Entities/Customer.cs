namespace MyVetAppointment.Data.Entities
{

    public class Customer : User
    {
        public ICollection<Animal>? Animals { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}