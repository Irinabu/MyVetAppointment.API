using MediatR;
using MyVetAppointment.API.Commands;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerByIdCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var user = _customerRepository.GetFirstAsync(u => u.Id == Guid.Parse(request.Id!));
            if (user == null)
                return false;
            await _customerRepository.DeleteAsync(user.Result);
            await _customerRepository.SaveChangesAsync();
            return true;
        }
    }
    
}
