namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
