namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class ContentItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int ModuleId { get; set; }
        public int? ParentId { get; set; }
        public bool IsLesson { get; set; } = false;
        public int? LessonId { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Module Module { get; set; } = null!;
        public ContentItem? Parent { get; set; }
        public Lesson? Lesson { get; set; }
        public ICollection<ContentItem> Children { get; set; } = new List<ContentItem>();
    }
}
