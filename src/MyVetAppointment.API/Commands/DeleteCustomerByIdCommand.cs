using MediatR;

namespace MyVetAppointment.API.Commands
{
    public class DeleteCustomerByIdCommand: IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
