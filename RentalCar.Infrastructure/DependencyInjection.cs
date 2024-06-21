using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SQLServerDatabase");
            EnsureDatabaseCreated(connectionString);
            services.AddDbContext<RentalCarDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        private static void EnsureDatabaseCreated(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RentalCarDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new RentalCarDbContext(optionsBuilder.Options))
            {
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}