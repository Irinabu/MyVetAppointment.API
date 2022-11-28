using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;
using System.Linq.Expressions;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class VetDoctorRepository : BaseRepository<VetDoctor>, IVetDoctorRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<User> _entities;
        public VetDoctorRepository(DatabaseContext appDbContext) : base(appDbContext)
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

        public Task<VetDoctor> DeleteAsync(VetDoctor entity)
        {
            throw new NotImplementedException();
        }

        public User Get(string id)
        {
            return _entities.SingleOrDefault(c => c.Id == new Guid(id));
        }

        public User GetVetDoctorByEmail(string email)
        {
            return _entities.SingleOrDefault(c => c.Email == email);
        }
    
        public IEnumerable<User> GetAll()
        {
            try
            {
                //var ent = _entities.AsEnumerable();
                var ent = _dbContext.VetDoctors.ToList();
                return ent;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Task<List<VetDoctor>> GetAllAsync(Expression<Func<VetDoctor, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Task<VetDoctor> GetFirstAsync(Expression<Func<VetDoctor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
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

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
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

        public Task<VetDoctor> UpdateAsync(VetDoctor entity)
        {
            throw new NotImplementedException();
        }
    }
}