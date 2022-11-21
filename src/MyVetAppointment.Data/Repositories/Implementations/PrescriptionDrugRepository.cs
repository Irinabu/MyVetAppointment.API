using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class PrescriptionDrugRepository: BaseRepository<PrescriptionDrug>,IPrescriptionDrugRepository
    {
        protected PrescriptionDrugRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
