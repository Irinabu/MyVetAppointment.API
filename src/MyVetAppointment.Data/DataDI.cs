using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Data.Repositories;
using MyVetAppointment.Data.Repositories.Implementations;

namespace MyVetAppointment.Data;

public static class DataDI
{
    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IVetDoctorRepository, VetDoctorRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAppointmentRepository, AppointmentRepository>();
        services.AddTransient<IBillRepository, BillRepository>();
        services.AddTransient<IDrugRepository, DrugRepository>();
        services.AddTransient<IPrescriptionDrugRepository, PrescriptionDrugRepository>();
        services.AddTransient<IAnimalRepository, AnimalRepository>();

        return services;
    }
}