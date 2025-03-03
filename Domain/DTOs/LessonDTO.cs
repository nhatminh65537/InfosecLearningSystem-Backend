namespace InfosecLearningSystem_Backend.Domain.DTOs
{
    public class LessonDTO
    {
        public string TypeName { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int Xp { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
