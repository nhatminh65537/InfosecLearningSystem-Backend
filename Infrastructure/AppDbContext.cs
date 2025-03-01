using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using InfosecLearningSystem_Backend.Infrastructure.Configurations;
using InfosecLearningSystem_Backend.Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;

namespace InfosecLearningSystem_Backend.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<ExternalLogin> ExternalLogins { get; set; }
        public DbSet<UserPermissionView> UserPermissionsView { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProgressState> ProgressStates { get; set; }
        public DbSet<LifecycleState> LifecycleStates { get; set; }
        public DbSet<ModuleTag> ModuleTags { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.ApplyConfiguration(new SystemConfigConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new ExternalLoginConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionViewConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());

            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new ProgressStateConfiguration());
            modelBuilder.ApplyConfiguration(new LifecycleStateConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleTagConfiguration());
            modelBuilder.ApplyConfiguration(new ContentItemConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new LessonTypeConfiguration());


            // DataSeed
            modelBuilder.ApplyConfiguration(new SystemConfigSeedData());
            modelBuilder.ApplyConfiguration(new RoleSeedData());
            modelBuilder.ApplyConfiguration(new PermissionSeedData());
            modelBuilder.ApplyConfiguration(new RolePermissionSeedData());
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new LifecycleStateSeedData());
            modelBuilder.ApplyConfiguration(new ProgressStateSeedData());
            modelBuilder.ApplyConfiguration(new LessonTypeSeedData());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
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
                       .UseSnakeCaseNamingConvention();
        }
    }
}
