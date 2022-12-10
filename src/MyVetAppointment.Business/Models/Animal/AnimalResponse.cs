using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Business.Models.Animal
{
    public class AnimalResponse
    {
        public string? Name { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
