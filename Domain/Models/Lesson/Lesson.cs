namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class Lesson
    {
        public int ContentItemId { get; set; }
        public string TypeName { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int Xp { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ContentItem ContentItem { get; set; } = null!;
        public LessonType Type { get; set; } = null!;
    }
}
