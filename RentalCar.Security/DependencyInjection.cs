using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RentalCar.Application.Common.Interfaces.Authentication;
using System.Text;

namespace RentalCar.Security
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings jwtSettings = new JwtSettings(configuration["JwtSecret"], int.Parse(configuration["TTLMinutes"]));
            services.AddSingleton(jwtSettings);
            services.AddSingleton<ISecurityProvider, SecurityProvider>();

            services
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}