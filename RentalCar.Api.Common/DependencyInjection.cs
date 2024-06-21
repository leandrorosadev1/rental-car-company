using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RentalCar.Api.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetCallingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddHttpContextAccessor();
            return services;
        }
    }
}
