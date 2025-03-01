using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.ContentItemId);
            builder.Property(l => l.Xp).HasDefaultValue(0);
            builder.Property(l => l.Duration).HasDefaultValue(0);
            builder.HasOne(l => l.Type)
                   .WithMany(lt => lt.Lessons)
                   .HasForeignKey(l => l.TypeName)
                   .HasPrincipalKey(lt => lt.Name);
            builder.Property(l => l.CreatedAt)
                   .HasDefaultValueSql("NOW()");
            builder.Property(l => l.UpdatedAt)
                   .HasDefaultValueSql("NOW()")
                   .ValueGeneratedOnAddOrUpdate();

        }
    }
}
