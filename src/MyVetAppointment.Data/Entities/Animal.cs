using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Data.Entities;

public class Animal
{
    public Guid Id { get; set; }
    public AnimalType AnimalType { get; set; }
    

}