using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Data.Entities;

public  class  User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    // public ICollection<Animal> Animals { get; set; }
    // public ICollection<User> Customers { get; set; }
    // public ICollection<User> VetDoctors { get; set; }
    //
    //
    // public ICollection<Appointment> Appointments { get; set; }
    // public UserType UserType { get; set; }
}