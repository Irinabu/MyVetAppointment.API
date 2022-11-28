using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;
using System.Linq.Expressions;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext appDbContext) : base(appDbContext)
        {

        }
    }
}