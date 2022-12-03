using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations;

public class VetDoctorRepository : BaseRepository<VetDoctor>, IVetDoctorRepository
{
    public VetDoctorRepository(DatabaseContext appDbContext) : base(appDbContext)
    {
    }
}