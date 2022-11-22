using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Data.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IEnumerable<User> GetAll();
        User Get(string id);
        User GetByEmail(string email);
        bool Insert(User entity);
        void Update(User entity);
        void Delete(User entity);
        void Remove(User entity);
        void SaveChanges();
    }
}
