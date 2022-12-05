using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Business.Models.Animal
{
    public class AnimalResponse
    {
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
