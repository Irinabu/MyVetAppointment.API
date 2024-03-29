﻿using MediatR;
using MyVetAppointment.API.Commands;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    public class DeleteVetDoctorByIdCommandHandler : IRequestHandler<DeleteVetDoctorByIdCommand, bool>
    {
        private readonly IVetDoctorRepository _vetDoctorRepository;

        public DeleteVetDoctorByIdCommandHandler(IVetDoctorRepository vetDoctorRepository)
        {
            _vetDoctorRepository = vetDoctorRepository;
        }
        public async Task<bool> Handle(DeleteVetDoctorByIdCommand request, CancellationToken cancellationToken)
        {
            var user = _vetDoctorRepository.GetFirstAsync(u => u.Id == Guid.Parse(request.Id!));
            if (user == null)
                return false;
            await _vetDoctorRepository.DeleteAsync(user.Result);
            await _vetDoctorRepository.SaveChangesAsync();
            return true;
        }
    }
}
