namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class ExternalLogin
    {
        public int UserId { get; set; }
        public string Provider { get; set; } = null!;
        public string ProviderUserId { get; set; } = null!;
        public string ProviderData { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
