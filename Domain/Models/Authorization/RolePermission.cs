    namespace InfosecLearningSystem_Backend.Domain.Models
{
    public class RolePermission
    {
        public string RoleName { get; set; } = null!;
        public string PermissionName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public Role Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}
