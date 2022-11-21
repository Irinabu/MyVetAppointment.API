using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(DatabaseContext context) : base(context)
        {
        }
    }
}