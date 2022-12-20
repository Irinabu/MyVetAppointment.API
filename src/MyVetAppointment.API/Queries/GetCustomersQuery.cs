using MediatR;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Queries
{
    public class GetCustomersQuery : IRequest<List<Customer>>
    {
    }
}
