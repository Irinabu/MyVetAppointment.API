using AutoMapper;
using MediatR;
using MyVetAppointment.API.Commands;
using MyVetAppointment.Business.Models;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    public class UpdateVetDoctorCommandHeandler: IRequestHandler<UpdateVetDoctorCommand, UpdateUserResponse>
    {
        private readonly IVetDoctorRepository _vetDoctorRepository;
        private readonly IMapper _mapper;

        public UpdateVetDoctorCommandHeandler(IVetDoctorRepository vetDoctorRepository, IMapper mapper)
        {
            _vetDoctorRepository = vetDoctorRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateVetDoctorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _vetDoctorRepository.GetFirstAsync(x => x.Id.Equals(request.VetDoctorId));
            if (entity != null)
            {
                entity.FirstName = request.UpdateVetDoctorRequest!.FirstName;
                entity.LastName = request.UpdateVetDoctorRequest.LastName;
                entity.Email = request.UpdateVetDoctorRequest.Email;
                entity.Password = request.UpdateVetDoctorRequest.Password;

                return _mapper.Map<VetDoctor, UpdateUserResponse>(await _vetDoctorRepository.UpdateAsync(entity));
            }
            UpdateUserResponse update = new UpdateUserResponse();
            return update;
        }
    }
}
