using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DatabaseContext appDbContext) : base(appDbContext)
    {
    }
}