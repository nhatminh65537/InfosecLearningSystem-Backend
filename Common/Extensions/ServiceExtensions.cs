using InfosecLearningSystem_Backend.Domain.Interfaces;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Infrastructure.Repositories;
using InfosecLearningSystem_Backend.Services;
using InfosecLearningSystem_Backend.Services.Interfaces;
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
            services.AddScoped(typeof(IDataService<CategoryDTO>), typeof(DataService<Category, CategoryDTO>));
            services.AddScoped(typeof(IDataService<LessonDTO>), typeof(DataService<Lesson, LessonDTO>));
            services.AddScoped(typeof(IDataService<LessonTypeDTO>), typeof(DataService<LessonType, LessonTypeDTO>));
            services.AddScoped(typeof(IDataService<LifecycleStateDTO>), typeof(DataService<LifecycleState, LifecycleStateDTO>));
            services.AddScoped(typeof(IDataService<ModuleDTO>), typeof(DataService<Module, ModuleDTO>));
            services.AddScoped(typeof(IDataService<PermissionDTO>), typeof(DataService<Permission, PermissionDTO>));
            services.AddScoped(typeof(IDataService<ProgressStateDTO>), typeof(DataService<ProgressState, ProgressStateDTO>));
            services.AddScoped(typeof(IDataService<RoleDTO>), typeof(DataService<Role, RoleDTO>));
            services.AddScoped(typeof(IDataService<SystemConfigDTO>), typeof(DataService<SystemConfig, SystemConfigDTO>));
            services.AddScoped(typeof(IDataService<TagDTO>), typeof(DataService<Tag, TagDTO>));
            services.AddScoped(typeof(IDataService<UserDTO>), typeof(DataService<User, UserDTO>));


        }

    }
}
