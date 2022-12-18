using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations
{

    public class PrescriptionDrugRepository : BaseRepository<PrescriptionDrug>, IPrescriptionDrugRepository
    {
        public PrescriptionDrugRepository(DatabaseContext context) : base(context)
        {
        }
    }
}