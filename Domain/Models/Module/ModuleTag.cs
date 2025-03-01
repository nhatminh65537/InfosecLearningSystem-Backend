namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class ModuleTag
    {
        public int ModuleId { get; set; }
        public string TagName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public Module Module { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}
