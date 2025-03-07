using InfosecLearningSystem_Backend.Domain.Interfaces;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Domain.Interfaces;
using InfosecLearningSystem_Backend.Infrastructure.Repositories;
using InfosecLearningSystem_Backend.Application.Services;
using InfosecLearningSystem_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InfosecLearningSystem_Backend.Application.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped(typeof(IDataService<CategoryDTO>), typeof(DataService<Category, CategoryDTO>));
            services.AddScoped(typeof(IDataService<LessonDTO>), typeof(DataService<Lesson, LessonDTO>));
            services.AddScoped(typeof(IDataService<LessonTypeDTO>), typeof(DataService<LessonType, LessonTypeDTO>));
            services.AddScoped(typeof(IDataService<LifecycleStateDTO>), typeof(DataService<LifecycleState, LifecycleStateDTO>));
            services.AddScoped(typeof(IDataService<ModuleDTO>), typeof(DataService<Module, ModuleDTO>));
            services.AddScoped(typeof(IDataService<PermissionDTO>), typeof(DataService<Permission, PermissionDTO>));
            services.AddScoped(typeof(IDataService<ProgressStateDTO>), typeof(DataService<ProgressState, ProgressStateDTO>));
            services.AddScoped(typeof(IDataService<SystemConfigDTO>), typeof(DataService<SystemConfig, SystemConfigDTO>));
            services.AddScoped(typeof(IDataService<TagDTO>), typeof(DataService<Tag, TagDTO>));


        }

        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var revocationService = context.HttpContext.RequestServices
                                .GetRequiredService<ITokenService>();

                            var jti = context.Principal?.FindFirstValue(JwtRegisteredClaimNames.Jti);

                            if (await revocationService.IsTokenRevokedAsync(jti!))
                            {
                                context.Fail("Token revoked");
                            }
                        },
                      
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                            return Task.CompletedTask;
                        },
                        //OnTokenValidated = context =>
                        //{
                        //    Console.WriteLine("Token successfully validated.");
                        //    return Task.CompletedTask;
                        //}
                    };
                   
                });
        }

        public static void AddAuthorizationPolicies(this IServiceCollection services)
        { 
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var _permissionRepository = serviceProvider.GetRequiredService<IRepository<Permission>>();
                var permissions = _permissionRepository.GetAll()
                                                       .Select(p => p.Name)
                                                       .ToList();

                services.AddAuthorization(options =>
                {
                    foreach (var permission in permissions)
                    {
                        options.AddPolicy(permission, policy =>
                            policy.Requirements.Add(new PermissionRequirement(permission)));
                    }
                });
            }
        }
        
    }
}
