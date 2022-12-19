using MediatR;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Commands
{
    public class DeleteCustomerByIdCommand: IRequest<string>
    {
        public string Id { get; set; }
    }
}
