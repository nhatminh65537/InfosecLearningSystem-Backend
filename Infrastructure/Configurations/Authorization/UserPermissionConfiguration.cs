using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasKey(up => new { up.UserId, up.PermissionName });

            builder.HasIndex(up => up.UserId);
            builder.HasIndex(up => up.PermissionName);
            builder.HasOne(up => up.User)
                   .WithMany()
                   .HasForeignKey(up => up.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(up => up.Permission)
                   .WithMany()
                   .HasForeignKey(up => up.PermissionName)
                   .HasPrincipalKey(p => p.Name)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(up => up.CreatedAt)
                   .HasDefaultValueSql("NOW()");
        }
    }
}
