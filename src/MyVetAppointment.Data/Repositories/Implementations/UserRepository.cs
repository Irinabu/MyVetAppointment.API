using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MyVetAppointment.Data.Repositories.Implementations;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    { }
}