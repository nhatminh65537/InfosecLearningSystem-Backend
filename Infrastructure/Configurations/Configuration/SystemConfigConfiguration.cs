using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class SystemConfigConfiguration : IEntityTypeConfiguration<SystemConfig>
    {
        public void Configure(EntityTypeBuilder<SystemConfig> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.HasIndex(sc => sc.Name).IsUnique();
            builder.Property(sc => sc.Value).IsRequired();
            builder.Property(sc => sc.Type).IsRequired();
            builder.Property(sc => sc.IsActive).HasDefaultValue(true);
            builder.Property(builder => builder.CreatedAt).HasDefaultValueSql("NOW()");
            builder.Property(builder => builder.UpdatedAt).HasDefaultValueSql("NOW()")
                                                          .ValueGeneratedOnAddOrUpdate();
        }
    }
}
