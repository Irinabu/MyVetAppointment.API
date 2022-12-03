using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Persistence;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Repositories.Implementations;

namespace MyVetAppointment.UnitTests.Config;

public class BaseTest
{
    private readonly DatabaseContext _databaseContext;

    public BaseTest()
    {
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        builder.UseInMemoryDatabase("LibraryDbInMemory");

        var dbContextOptions = builder.Options;
        _databaseContext = new DatabaseContext(dbContextOptions);
        // Delete existing db before creating a new one
        _databaseContext.Database.EnsureDeleted();
        _databaseContext.Database.EnsureCreated();
    }

    public IUserRepository GetInMemoryReadRepository()
    {
        return new UserRepository(_databaseContext);
    }
}