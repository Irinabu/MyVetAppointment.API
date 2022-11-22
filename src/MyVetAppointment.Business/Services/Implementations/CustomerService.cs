using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool DeleteCustomer(string id)
        {
            var user = _customerRepository.Get(id);
            if (user == null) 
                return false;
            _customerRepository.Remove(user);
            _customerRepository.SaveChanges();
            return true;
        }

        public IEnumerable<User> GetAllCustomersAsync()
        {
            return _customerRepository.GetAll();
        }


/*        Task<IEnumerable<User>> ICustomerService.GetAllCustomersAsync()
        {
            return (Task<IEnumerable<User>>)_customerRepository.GetAll();
        }*/
    }
}
