namespace InfosecLearningSystem_Backend.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? EmailVerifiedAt { get; set; }
        public bool RequirePasswordReset { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
