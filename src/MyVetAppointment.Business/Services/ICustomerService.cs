using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services
{
    public interface ICustomerService
    {
        IEnumerable<User> GetAllCustomersAsync();
        bool DeleteCustomer(string id);
    }
}