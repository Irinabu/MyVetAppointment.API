using MediatR;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.API.Commands
{
    public class AddNewAnimalCommand : IRequest<AnimalResponse>
    {
        public AnimalRequest AnimalRequest { get; set; }
        public string UserId { get; set; }

    }
}
