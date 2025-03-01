namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<ModuleTag> ModuleTags { get; set; } = new List<ModuleTag>();
    }
}
