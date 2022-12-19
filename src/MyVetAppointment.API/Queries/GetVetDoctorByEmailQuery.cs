using MediatR;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Queries
{
    public class GetVetDoctorByEmailQuery : IRequest<VetDoctor>
    {
        public string? Email { get; set; }
    }
}
