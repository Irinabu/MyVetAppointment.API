using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Business.MappingProfiles;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;
using MyVetAppointment.Data.Persistence;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Repositories.Implementations;
using MyVetAppointment.UnitTests;

namespace Application.UnitTests;

public class DITests : IDisposable
{
    private readonly ServiceProvider _serviceProvider;

    public DITests()
    {
        var services = InitializeCommonServices();

        _serviceProvider = services.BuildServiceProvider();

        DatabaseInitializer.Initialize(ResolveService<DatabaseContext>());
    }

    public void Dispose()
    {
        ResolveService<DatabaseContext>().Database.EnsureDeleted();
        _serviceProvider.Dispose();
        GC.Collect();
    }

    public ServiceCollection InitializeCommonServices()
    {
        var services = new ServiceCollection();

        services.AddAutoMapper(typeof(IMappingProfilesMarker));
        services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            }
        );

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IVetDoctorRepository, VetDoctorRepository>();

        services.AddTransient<IAuthenticateService, AuthenticateService>();
        services.AddTransient<JwtService>();
        return services;
    }

    public T ResolveService<T>()
    {
        return _serviceProvider.GetService<T>();
    }
}