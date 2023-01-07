using AutoMapper;
using MediatR;
using MyVetAppointment.API.Commands;
using MyVetAppointment.Business.Models;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, UpdateUserResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetFirstAsync(x => x.Id.Equals(request.CustomerId));
            if (entity != null)
            {
                entity.FirstName=request.UpdateCustomerRequest!.FirstName;
                entity.LastName=request.UpdateCustomerRequest.LastName;
                entity.Email=request.UpdateCustomerRequest.Email;
                entity.Password=request.UpdateCustomerRequest.Password;

                return _mapper.Map<Customer, UpdateUserResponse>(await _customerRepository.UpdateAsync(entity));
            }
            UpdateUserResponse update = new UpdateUserResponse();
            return update;
        }
    }
}
