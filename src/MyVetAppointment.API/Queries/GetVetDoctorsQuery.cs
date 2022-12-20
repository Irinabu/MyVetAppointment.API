using MediatR;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.API.Queries
{
    public class GetVetDoctorsQuery: IRequest<List<VetDoctor>>
    {
    }
}
