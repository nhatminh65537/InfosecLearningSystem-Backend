using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Infrastructure.Repositories;
using InfosecLearningSystem_Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Components;
using AutoMapper;
using InfosecLearningSystem_Backend.Application.Interfaces;

namespace InfosecLearningSystem_Backend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<UserPermission> _userPermissionRepository;
        private readonly IRepository<UserPermissionView> _userPermissionViewRepository;
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;

        public UserService(
            IRepository<User> userRepository,
            IRepository<UserRole> userRoleRepository,
            IRepository<UserPermission> userPermissionRepository,
            IRepository<UserPermissionView> userPermissionViewRepository,
            IRepository<UserProfile> userProfileRepository,
            IRepository<Role> roleRepository,
            IRepository<Permission> permissionRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _userPermissionRepository = userPermissionRepository;
            _userPermissionViewRepository = userPermissionViewRepository;
            _userProfileRepository = userProfileRepository;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetFirstWhereAsync(u => u.UserName == username);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task AddUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(userDTO.Id)
                ?? throw new KeyNotFoundException("User not found");
            _mapper.Map(userDTO, user);
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
            await _userRepository.SaveAsync();
        }

        public async Task<IEnumerable<RoleDTO>> GetRolesOfUserAsync(int userId)
        {
            var userRoles = await _userRoleRepository.GetWhereAsync(ur => ur.UserId == userId);
            var roleNames = userRoles.Select(ur => ur.RoleName);
            var roles = await _roleRepository.GetWhereAsync(r => roleNames.Contains(r.Name));
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task AddRoleToUserAsync(int userId, string roleName)
        {
            var userRole = new UserRole { UserId = userId, RoleName = roleName};
            await _userRoleRepository.AddAsync(userRole);
            await _userRoleRepository.SaveAsync();
        }

        public async Task RemoveRoleFromUserAsync(int userId, string roleName)
        {
            await _userRoleRepository.DeleteWhereAsync(ur => ur.UserId == userId && ur.RoleName == roleName);
            await _userRoleRepository.SaveAsync();
        }

        public async Task<IEnumerable<PermissionDTO>> GetPermissionsOfUserAsync(int userId)
        {
            var userPermissions = await _userPermissionViewRepository.GetWhereAsync(upv => upv.UserId == userId);
            var permissionNames = userPermissions.Select(upv => upv.PermissionName);
            var permissions = await _permissionRepository.GetWhereAsync(p => permissionNames.Contains(p.Name));
            return _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
        }

        public async Task AddPermissionToUserAsync(int userId, string permissionName)
        {
                var userPermission = new UserPermission { UserId = userId, PermissionName = permissionName, CreatedAt = DateTime.UtcNow };
                await _userPermissionRepository.AddAsync(userPermission);
                await _userPermissionRepository.SaveAsync();
        }

        public async Task RemovePermissionFromUserAsync(int userId, string permissionName)
        {
            await _userPermissionRepository.DeleteWhereAsync(up => up.UserId == userId && up.PermissionName == permissionName);
            await _userPermissionRepository.SaveAsync();
        }


    }
}
