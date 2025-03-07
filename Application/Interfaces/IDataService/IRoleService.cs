using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> GetRoleByNameAsync(string roleName);
        Task AddRoleAsync(RoleDTO roleDTO);
        Task UpdateRoleAsync(RoleDTO roleDTO);
        Task DeleteRoleAsync(string roleName);
        Task<IEnumerable<PermissionDTO>> GetPermissionsInRoleAsync(string roleName);
        Task AddPermissionToRoleAsync(string roleName, string permissionName);
        Task RemovePermissionFromRoleAsync(string roleName, string permissionName);
    }
}
