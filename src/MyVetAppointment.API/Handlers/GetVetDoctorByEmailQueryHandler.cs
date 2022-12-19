using MediatR;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Repositories.Implementations;

namespace MyVetAppointment.API.Handlers
{
    public class GetVetDoctorByEmailQueryHandler: IRequestHandler<GetVetDoctorByEmailQuery, VetDoctor>
    {
        private readonly IVetDoctorRepository _vetDoctorRepository;

        public GetVetDoctorByEmailQueryHandler(IVetDoctorRepository vetDoctorRepository)
        {
            _vetDoctorRepository = vetDoctorRepository;
        }

        public async Task<VetDoctor> Handle(GetVetDoctorByEmailQuery request, CancellationToken cancellationToken)
        {
            return  _vetDoctorRepository.GetFirstAsync(u => u.Email == request.Email).Result;
        }
    }
}
