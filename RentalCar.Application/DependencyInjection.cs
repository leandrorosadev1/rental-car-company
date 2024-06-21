using Microsoft.Extensions.DependencyInjection;
using RentalCar.Application.Common.Services;

namespace RentalCar.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped<PlatformRolesService>();
            services.AddScoped<CountriesService>();
            services.AddScoped<CustomerUsersService>();
            services.AddScoped<CarsService>();
            return services;
        }
    }
}
