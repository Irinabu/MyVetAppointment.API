using MediatR;
using MyVetAppointment.Business.Models;

namespace MyVetAppointment.API.Commands
{
    public class UpdateVetDoctorCommand: IRequest<UpdateUserResponse>
    {
        public UpdateUserRequest? UpdateVetDoctorRequest { get; set; }
        public Guid VetDoctorId { get; set; }
    }
}
