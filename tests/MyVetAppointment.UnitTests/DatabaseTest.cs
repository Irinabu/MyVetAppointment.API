using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Persistence;
using MyVetAppointment.UnitTests;

namespace Application.UnitTests
{

    public class DatabaseTest : IDisposable
    {
        protected readonly DatabaseContextTest context;

        public DatabaseTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("TestDatabase").Options;
            context = new DatabaseContextTest(options);
            context.Database.EnsureCreated();
            DatabaseInitializer.Initialize(context);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}