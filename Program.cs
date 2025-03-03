using InfosecLearningSystem_Backend.Test;
using InfosecLearningSystem_Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using InfosecLearningSystem_Backend.Common.Extensions;
using InfosecLearningSystem_Backend.Domain.MappingProfiles;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"),
                      o => o.SetPostgresVersion(new Version(17, 4))));

            builder.Services.AddScoped<DbContext, AppDbContext>();

            builder.Services.AddRepositories();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddServices();

            builder.Services.AddOpenApi();

            builder.Services.AddControllers();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                PreTest(app.Configuration);
            }

            //app.UseExceptionHandler();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void PreTest(IConfiguration configuration)
        {
            // Test the connection to the PostgreSQL database
            PostgresConnectionTester tester = new(configuration);
            tester.TestConnection();
        }
    }
}
