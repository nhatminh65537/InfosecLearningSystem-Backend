using InfosecLearningSystem_Backend.Domain.Interfaces;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Infrastructure.Repositories;
using InfosecLearningSystem_Backend.Services;
using Microsoft.AspNetCore.Identity;

namespace InfosecLearningSystem_Backend.Common.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<PasswordService>();
        }


    }
}
