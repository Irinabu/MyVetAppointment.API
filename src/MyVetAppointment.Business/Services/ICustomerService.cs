using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerByEmailAsync(string email);
        bool UpdateCustomerAsync(string id, UpdateRequest model);
        bool DeleteCustomer(string id);

        List<Customer> GetAllAsync();
    }
}