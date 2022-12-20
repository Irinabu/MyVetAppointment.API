using MediatR;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Queries
{
    public class GetCustomerAnimalsQuery: IRequest<List<AnimalResponse>>
    {
        public string? Id { get; set; }
    }
}
