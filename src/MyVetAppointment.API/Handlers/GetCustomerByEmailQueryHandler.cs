using MediatR;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByEmailQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            return _customerRepository.GetFirstAsync(u => u.Email == request.Email).Result;
        }
    }
}
