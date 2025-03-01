namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class SystemConfig
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Category { get; set; }
        public string? DefaultValue { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
