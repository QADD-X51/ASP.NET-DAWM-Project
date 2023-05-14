using DAWM_Project.Data;
using DAWM_Project.Data.Repositories;
using DAWM_Project.Services;
using Microsoft.AspNetCore.Authentication;
using System;

namespace DAWM_Project.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDbContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<CarService>();
            services.AddScoped<AuthorizationService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<UserRepository>();
            services.AddScoped<CarRepository>();
            services.AddScoped<UnitOfWork>();
        }

    }
}
