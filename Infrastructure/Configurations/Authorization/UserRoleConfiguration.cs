using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleName });
            builder.HasIndex(ur => ur.UserId);
            builder.HasIndex(ur => ur.RoleName);
            builder.HasOne(ur => ur.User)
                   .WithMany()
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ur => ur.Role)
                   .WithMany()
                   .HasForeignKey(ur => ur.RoleName)
                   .HasPrincipalKey(r => r.Name)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(ur => ur.CreatedAt)
                   .HasDefaultValueSql("NOW()");
        }
    }
}
