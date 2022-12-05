using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Data.Entities;

public class Animal
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public AnimalType AnimalType { get; set; }
    public Customer Owner { get; set; }
}