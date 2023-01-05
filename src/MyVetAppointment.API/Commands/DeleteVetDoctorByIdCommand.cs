using MediatR;

namespace MyVetAppointment.API.Commands
{
    public class DeleteVetDoctorByIdCommand: IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
