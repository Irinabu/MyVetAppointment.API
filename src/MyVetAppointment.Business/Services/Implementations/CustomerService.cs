using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Business.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public bool DeleteCustomer(string id)
    {
        var user = _customerRepository.GetFirstAsync(u => u.Id == Guid.Parse(id));
        if (user == null)
            return false;
        _customerRepository.DeleteAsync(user.Result);
        _customerRepository.SaveChangesAsync();
        return true;
    }

    public List<Customer> GetAllAsync()
    {
        return _customerRepository.GetAllAsync(exp => true).Result;
    }


    public Customer GetCustomerByEmailAsync(string email)
    {
        return _customerRepository.GetFirstAsync(u => u.Email == email).Result;
    }

}