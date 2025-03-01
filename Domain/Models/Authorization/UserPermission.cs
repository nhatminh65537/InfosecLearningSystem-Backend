namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class UserPermission
    {
        public int UserId { get; set; }
        public string PermissionName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}
