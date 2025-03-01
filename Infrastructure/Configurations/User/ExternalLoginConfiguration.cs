using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class ExternalLoginConfiguration : IEntityTypeConfiguration<ExternalLogin>
    {
        public void Configure(EntityTypeBuilder<ExternalLogin> builder)
        {
            builder.HasKey(el => new { el.UserId, el.Provider });
            builder.HasIndex(el => el.ProviderUserId);
            builder.HasOne(el => el.User)
                   .WithMany()
                   .HasForeignKey(el => el.UserId);
        }
    }
}
