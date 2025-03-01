using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class LessonTypeConfiguration : IEntityTypeConfiguration<LessonType>
    {
        public void Configure(EntityTypeBuilder<LessonType> builder)
        {
            builder.HasKey(lt => lt.Id);
            builder.HasIndex(lt => lt.Name).IsUnique();
        }
    }
}
