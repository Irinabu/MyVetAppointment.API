using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class DrugRepository:BaseRepository<Drug>,IDrugRepository
    {
        protected DrugRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
