using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class ModuleTagConfiguration : IEntityTypeConfiguration<ModuleTag>
    {
        public void Configure(EntityTypeBuilder<ModuleTag> builder)
        {
            builder.HasKey(mt => new { mt.ModuleId, mt.TagName });
            builder.HasOne(mt => mt.Module)
                   .WithMany(m => m.ModuleTags)
                   .HasForeignKey(mt => mt.ModuleId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mt => mt.Tag)
                   .WithMany(t => t.ModuleTags)
                   .HasForeignKey(mt => mt.TagName)
                   .HasPrincipalKey(t => t.Name)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Property(mt => mt.CreatedAt)
                   .HasDefaultValueSql("NOW()");
        }
    }
}
