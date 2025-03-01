using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(m => m.Title).IsUnique();
            builder.Property(m => m.Xp).HasDefaultValue(0);
            builder.Property(m => m.Duration).HasDefaultValue(0);
            builder.HasOne(m => m.Category)
                   .WithMany(c => c.Modules)
                   .HasForeignKey(m => m.CategoryId);
            builder.HasOne(m => m.ProgressState)
                   .WithMany()
                   .HasForeignKey(m => m.ProgressStateName)
                   .HasPrincipalKey(ps => ps.Name);
            builder.HasOne(m => m.LifecycleState)
                   .WithMany()
                   .HasForeignKey(m => m.LifecycleStateName)
                   .HasPrincipalKey(ls => ls.Name);
            builder.Property(m => m.CreatedAt)
                   .HasDefaultValueSql("NOW()");
            builder.Property(m => m.UpdatedAt)
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAddOrUpdate();
        }
    }
}
