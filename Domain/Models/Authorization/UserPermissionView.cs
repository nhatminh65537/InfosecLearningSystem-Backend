namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class UserPermissionView
    {
        public int UserId { get; set; }
        public string PermissionName { get; set; } = null!;
        public Permission Permission { get; set; } = null!;

    }
}
