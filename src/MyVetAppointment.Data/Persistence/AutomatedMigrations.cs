using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Data.Persistence;

public static class AutomatedMigration
{
    public static async Task MigrateAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<DatabaseContext>();

        if (context.Database.IsSqlServer()) await context.Database.MigrateAsync();
        var userRepository = services.GetRequiredService<IUserRepository>();
        var appointmentRepository = services.GetRequiredService<IAppointmentRepository>();
        var billRepository = services.GetRequiredService<IBillRepository>();
        var mapper = services.GetRequiredService<IMapper>();

        await DatabaseContextSeed.SeedDatabaseAsync(context, userRepository, appointmentRepository, billRepository,
            mapper);
    }
}