using MyVetAppointment.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Business.Models.Animal
{
    public class AnimalRequest
    {
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}
