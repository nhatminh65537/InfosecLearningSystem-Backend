using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.SeedData
{
    public class LessonTypeSeedData : IEntityTypeConfiguration<LessonType>
    {
        public void Configure(EntityTypeBuilder<LessonType> builder)
        {
            builder.HasData(
                new LessonType { Id = 1, Name = "Video", Description = "Video lesson" },
                new LessonType { Id = 2, Name = "Markdown", Description = "Markdown lesson" },
                new LessonType { Id = 3, Name = "Quiz", Description = "Quiz lesson" }
            );
        }
    }
}
