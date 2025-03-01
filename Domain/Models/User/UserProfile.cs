namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string DisplayName { get; set; } = null!;
        public int Xp { get; set; } = 0;
        public int Level { get; set; } = 1;
        public string? AvatarPath { get; set; }

        public User User { get; set; } = null!;
    }
}
