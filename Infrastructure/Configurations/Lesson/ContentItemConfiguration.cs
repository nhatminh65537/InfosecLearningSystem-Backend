using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class ContentItemConfiguration : IEntityTypeConfiguration<ContentItem>
    {
        public void Configure(EntityTypeBuilder<ContentItem> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.HasOne(ci => ci.Module)
                   .WithMany(m => m.ContentItems)
                   .HasForeignKey(ci => ci.ModuleId);
            builder.HasOne(ci => ci.Parent)
                   .WithMany(p => p.Children)
                   .HasForeignKey(ci => ci.ParentId);
            builder.HasOne(ci => ci.Lesson)
                   .WithOne(l => l.ContentItem)
                   .HasForeignKey<Lesson>(l => l.ContentItemId);
            builder.Property(ci => ci.CreatedAt)
                   .HasDefaultValueSql("NOW()");
            builder.Property(ci => ci.UpdatedAt)
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAddOrUpdate();
        }
    }
}
