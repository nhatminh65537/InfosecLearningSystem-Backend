using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PasswordHash)
                   .IsRequired();
            builder.Property(u => u.RequirePasswordReset).HasDefaultValue(false);
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("NOW()");
            builder.Property(u => u.UpdatedAt)
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAddOrUpdate();
        }
    }
}
