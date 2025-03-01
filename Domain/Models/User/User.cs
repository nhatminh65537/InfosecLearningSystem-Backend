namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? EmailVerifiedAt { get; set; }
        public string PasswordHash { get; set; } = null!;
        public bool RequirePasswordReset { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
