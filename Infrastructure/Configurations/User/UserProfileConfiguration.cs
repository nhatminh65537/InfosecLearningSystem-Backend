using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.UserId);
            builder.HasIndex(up => up.DisplayName).IsUnique();
            builder.Property(up => up.Xp).HasDefaultValue(0);
            builder.Property(up => up.Level).HasDefaultValue(1);
            builder.HasOne(up => up.User)
                   .WithOne()
                   .HasForeignKey<UserProfile>(up => up.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
