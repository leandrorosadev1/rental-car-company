using Microsoft.OpenApi.Models;
using RentalCar.Api.Common;
using RentalCar.Api.Common.Exceptions;

namespace RentalCar.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });

            services.AddPermissionValidation();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "RentalCar API" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddMapping();
            return services;
        }

        private static IServiceCollection AddPermissionValidation(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("VEHICLE_ADD", policy =>
                    policy.RequireClaim("permissions", "VEHICLE_ADD"));

                options.AddPolicy("VEHICLE_REMOVE", policy =>
                    policy.RequireClaim("permissions", "VEHICLE_REMOVE"));

                options.AddPolicy("RENTAL_ADD", policy =>
                    policy.RequireClaim("permissions", "RENTAL_ADD"));

                options.AddPolicy("RENTAL_CANCEL", policy =>
                    policy.RequireClaim("permissions", "RENTAL_CANCEL"));

                options.AddPolicy("CUSTOMER_REMOVE", policy =>
                    policy.RequireClaim("permissions", "CUSTOMER_REMOVE"));

                options.AddPolicy("RENTAL_RETURN", policy =>
                    policy.RequireClaim("permissions", "RENTAL_RETURN"));
            });
            return services;
        }
    }
}
