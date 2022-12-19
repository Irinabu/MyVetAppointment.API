using MediatR;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Queries
{
    public class GetCustomerByIdQuery:IRequest<string>
    {
        public string? Id { get; set; }
    }
}
