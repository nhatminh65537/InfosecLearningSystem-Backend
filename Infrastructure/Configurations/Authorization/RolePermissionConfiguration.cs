using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => new { rp.RoleName, rp.PermissionName });
            builder.HasIndex(rp => rp.RoleName);
            builder.HasIndex(rp => rp.PermissionName);
            builder.HasOne(rp => rp.Role)
                   .WithMany()
                   .HasForeignKey(rp => rp.RoleName)
                   .HasPrincipalKey(r => r.Name)
                   .OnDelete(DeleteBehavior.Cascade);   
            builder.HasOne(rp => rp.Permission)
                   .WithMany()
                   .HasForeignKey(rp => rp.PermissionName)
                   .HasPrincipalKey(p => p.Name)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(rp => rp.CreatedAt).HasDefaultValueSql("NOW()");
        }
    }
}
