namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string ProgressStateName { get; set; } = null!;
        public string LifecycleStateName { get; set; } = null!;
        public int Xp { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Category Category { get; set; } = null!;
        public ProgressState ProgressState { get; set; } = null!;
        public LifecycleState LifecycleState { get; set; } = null!;
        public ICollection<ModuleTag> ModuleTags { get; set; } = new List<ModuleTag>();
        public ICollection<ContentItem> ContentItems { get; set; } = new List<ContentItem>();
    }
}
