using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class LifecycleStateConfiguration : IEntityTypeConfiguration<LifecycleState>
    {
        public void Configure(EntityTypeBuilder<LifecycleState> builder)
        {
            builder.HasKey(ls => ls.Id);
            builder.HasIndex(ls => ls.Name).IsUnique();
        }
    }
}
