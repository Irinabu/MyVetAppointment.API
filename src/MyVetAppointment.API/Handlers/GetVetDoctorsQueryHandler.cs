using MediatR;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Repositories.Implementations;

namespace MyVetAppointment.API.Handlers
{
    public class GetVetDoctorsQueryHandler: IRequestHandler<GetVetDoctorsQuery, List<VetDoctor>>
    {
        private readonly IVetDoctorRepository _vetDoctorRepository;

        public GetVetDoctorsQueryHandler(IVetDoctorRepository vetDoctorRepository)
        {
            this._vetDoctorRepository = vetDoctorRepository;
        }

        public async Task<List<VetDoctor>> Handle(GetVetDoctorsQuery request, CancellationToken cancellationToken)
        {

            return await _vetDoctorRepository.GetAllAsync(exp => true);
        }
    }
}
