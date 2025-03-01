using InfosecLearningSystem_Backend.Test;
using InfosecLearningSystem_Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using InfosecLearningSystem_Backend.Domain.Models;

namespace InfosecLearningSystem_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"),
                                  o => o.SetPostgresVersion(new Version(17, 4)))
                       .UseSeeding(
                            (context, _) =>
                            {
                                var first = context.Set<User>().FirstOrDefault();
                                if (first == null)
                                { 
                                    var newUser = new User
                                    {
                                        Id = 1,
                                        UserName = "admin",
                                        Email = "admin@example.com"
                                    };
                                    newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, "admin");
                                    context.Set<User>().Add(newUser);
                                    context.Set<UserRole>().Add(new UserRole { UserId = newUser.Id, RoleName = "Admin" });

                                    context.SaveChanges();

                                    
                                }
                            })
                       .UseAsyncSeeding(
                            async (context, _, cancellationToken) =>
                            {
                            var first = await context.Set<User>().FirstOrDefaultAsync(cancellationToken);
                            if (first == null)
                            {
                                var newUser = new User
                                {
                                    Id = 1,
                                    UserName = "admin",
                                    Email = "admin@example.com"
                                };
                                newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, "admin");
                                context.Set<User>().Add(newUser);
                                context.Set<UserRole>().Add(new UserRole { UserId = newUser.Id, RoleName = "Admin" });

                                await context.SaveChangesAsync(cancellationToken);
                                }
                       })
                   .UseSnakeCaseNamingConvention());
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                PreTest(app.Configuration);
            }

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
