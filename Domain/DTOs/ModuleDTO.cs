namespace InfosecLearningSystem_Backend.Domain.DTOs
{
    public class ModuleDTO
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string ProgressStateName { get; set; } = null!;
        public string LifecycleStateName { get; set; } = null!;
        public int Xp { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
