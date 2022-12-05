using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations;

public class DrugRepository : BaseRepository<Drug>, IDrugRepository
{
    public DrugRepository(DatabaseContext context) : base(context)
    {
    }
}