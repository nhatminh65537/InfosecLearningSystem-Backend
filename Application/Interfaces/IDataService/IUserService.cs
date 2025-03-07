using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<UserDTO> GetUserByUsernameAsync(string username);
        Task AddUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<RoleDTO>> GetRolesOfUserAsync(int userId);
        Task AddRoleToUserAsync(int userId, string roleName);
        Task RemoveRoleFromUserAsync(int userId, string roleName);
        Task<IEnumerable<PermissionDTO>> GetPermissionsOfUserAsync(int userId);
        Task AddPermissionToUserAsync(int userId, string permissionName);
        Task RemovePermissionFromUserAsync(int userId, string permissionName);
    }
}
