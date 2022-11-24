using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;
using System.Linq.Expressions;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<User> _entities;

        public CustomerRepository(DatabaseContext appDbContext) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _entities = _dbContext.Set<User>();
        }

        public void Delete(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public User Get(string id)
        {
            return _entities.SingleOrDefault(c => c.Id == new Guid(id));
        }

        public User GetByEmail(string email)
        {
            return _entities.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var ent = _entities.AsEnumerable();
                return ent;
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION_________________________________________________");
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public bool Insert(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _entities.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void Remove(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }


        public void Update(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Update(entity);
            _dbContext.SaveChanges();
        }

        public Task<Customer> GetFirstAsync(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }
    }
}