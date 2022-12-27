using MediatR;
using MyVetAppointment.Business.Models;

namespace MyVetAppointment.API.Commands
{
    public class UpdateCustomerCommand: IRequest<UpdateUserResponse>
    {
        public UpdateUserRequest? UpdateCustomerRequest { get; set; }
        public Guid CustomerId { get; set; }
    }
}
