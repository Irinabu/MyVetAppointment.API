using MediatR;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Queries
{
    public class GetCustomerByEmailQuery : IRequest<Customer>
    {
        public string? Email { get; set; }
    }
}
