using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.Interfaces;
using InfosecLearningSystem_Backend.Application.Interfaces;
using AutoMapper;

namespace InfosecLearningSystem_Backend.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<RolePermission> _rolePermissionRepository;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;

        public RoleService(
            IRepository<Role> roleRepository,
            IRepository<RolePermission> rolePermissionRepository,
            IRepository<Permission> permissionRepository,
            IMapper mapper )
        {
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task<RoleDTO> GetRoleByNameAsync(string roleName)
        {
            var role = await _roleRepository.GetWhereAsync(
                r => r.Name == roleName
            );
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task AddRoleAsync(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveAsync();
        }

        public async Task UpdateRoleAsync(RoleDTO roleDTO)
        {
            Role? role = await _roleRepository.GetFirstWhereAsync(
                r => r.Name == roleDTO.Name
            ) ?? throw new KeyNotFoundException("Role not found");

            _mapper.Map(roleDTO, role);

            await _roleRepository.UpdateAsync(role);
            await _roleRepository.SaveAsync();
        }

        public async Task DeleteRoleAsync(string RoleName)
        {
            await _roleRepository.DeleteWhereAsync(r => r.Name == RoleName);
            await _roleRepository.SaveAsync();
        }

        public async Task<IEnumerable<PermissionDTO>> GetPermissionsInRoleAsync(string roleName)
        {
            var rolePermissions = await _rolePermissionRepository.GetWhereAsync(
                rp => rp.RoleName == roleName
            );
            var permissionNames = rolePermissions
                                  .Select(rp => rp.PermissionName);

            var permissions = await _permissionRepository.GetWhereAsync(
                p => permissionNames.Contains(p.Name)
            );

            return _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
        }

        public async Task AddPermissionToRoleAsync(string roleName, string permissionName)
        {
            var rolePermission = new RolePermission
            {
                RoleName = roleName,
                PermissionName = permissionName,
            };
            await _rolePermissionRepository.AddAsync(rolePermission);
            await _rolePermissionRepository.SaveAsync();
        }

        public async Task RemovePermissionFromRoleAsync(string roleName, string permissionName)
        {
            await _rolePermissionRepository.DeleteWhereAsync(
                rp => rp.RoleName == roleName && rp.PermissionName == permissionName
            );
            await _rolePermissionRepository.SaveAsync();
        }
    }
}
