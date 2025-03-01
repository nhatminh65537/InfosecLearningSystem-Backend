namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public string RoleName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
