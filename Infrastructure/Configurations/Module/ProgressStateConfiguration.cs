using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class ProgressStateConfiguration : IEntityTypeConfiguration<ProgressState>
    {
        public void Configure(EntityTypeBuilder<ProgressState> builder)
        {
            builder.HasKey(ps => ps.Id);
            builder.HasIndex(ps => ps.Name).IsUnique();
        }
    }
}
