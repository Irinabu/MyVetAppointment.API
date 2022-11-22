using Microsoft.Extensions.DependencyInjection;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;

namespace MyVetAppointment.Business
{
    public static class BussinessDI
    {
        public static IServiceCollection InjectBussinesServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddTransient<JwtService>();
            return services;
        }
    }
}