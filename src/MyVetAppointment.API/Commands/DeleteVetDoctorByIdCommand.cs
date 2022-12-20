using MediatR;

namespace MyVetAppointment.API.Commands
{
    public class DeleteVetDoctorByIdCommand: IRequest<string>
    {
        public string? Id { get; set; }
    }
}
