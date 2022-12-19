using MediatR;
using MyVetAppointment.API.Commands;
using MyVetAppointment.API.Queries;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.API.Handlers
{
    //public class DeleteCustomerByIdQueryHandler : IRequestHandler<DeleteCustomerByIdQuery, Customer>
    //{
    //    private readonly ICustomerRepository _customerRepository;

    //    public DeleteCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    //    {
    //        _customerRepository = customerRepository;
    //    }

    //    public async Task<Customer> Handle(DeleteCustomerByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        var user = _customerRepository.GetFirstAsync(u => u.Id == request.Id);
    //        if (user == null)
    //            return false;
    //        _customerRepository.DeleteAsync(user.Result);
    //        _customerRepository.SaveChangesAsync();
    //        return true;
    //        // return _customerRepository.GetAll().FirstOrDefault(x => x.Id == request.Id);
    //        //return _customerRepository.GetFirstAsync(u => u.Email == request.Email).Result;
    //        //return await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    //    }


    //}

    
    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerByIdCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var user = _customerRepository.GetFirstAsync(u => u.Id == Guid.Parse(request.Id));
            if (user == null)
                return "";
            _customerRepository.DeleteAsync(user.Result);
            _customerRepository.SaveChangesAsync();
            return "true";
        }

        
    }
    
}
