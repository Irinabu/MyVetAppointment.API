using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Business.MappingProfiles;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;
using MyVetAppointment.Business.Validators;

namespace MyVetAppointment.Business;

public static class BusinessDI
{
    public static IServiceCollection InjectBusinessServices(this IServiceCollection services)
    {
        // Add services to the container.
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
        //validators
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IAuthenticateService, AuthenticateService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IVetDoctorService, VetDoctorService>();
        services.AddTransient<IAppointmentService, AppointmentService>();
        services.AddTransient<IBillService, BillService>();
        services.AddTransient<IDrugService, DrugService>();
        services.AddTransient<JwtService>();
        // services.AddTransient<IValidator<AppointmentRequest>, AppointmentValidator>();
        // services.AddTransient<IValidator<BillRequest>, BillValidator>();
        // services.AddTransient<IValidator<PrescriptionDrugRequest>, PrescriptionDrugValidator>();
        // services.AddTransient<IValidator<DrugRequest>, DrugValidator>();
        // services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
        // services.AddTransient<IValidator<RegisterRequest>, RegisterValidator>();
        // services.AddTransient<IValidator<AnimalRequest>, AnimalValidator>();
        return services;
    }
}