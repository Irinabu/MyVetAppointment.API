using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;
using System.Linq.Expressions;

namespace MyVetAppointment.Data.Repositories.Implementations
{
    public class VetDoctorRepository : BaseRepository<VetDoctor>, IVetDoctorRepository
    {
        public VetDoctorRepository(DatabaseContext appDbContext) : base(appDbContext)
        {

        }
    }
}