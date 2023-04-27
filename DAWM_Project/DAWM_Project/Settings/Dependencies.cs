using System;

namespace DAWM_Project.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            //applicationBuilder.Services.AddDbContext<AppDbContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            //services.AddScoped</*Service class here*/>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            //services.AddScoped<StudentsRepository>();
            //services.AddScoped<UnitOfWork>();
        }

    }
}
