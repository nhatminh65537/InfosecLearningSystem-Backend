using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.Interfaces;
using System.Linq.Expressions;

namespace InfosecLearningSystem_Backend.Application.Services
{
    public class CheckPermissionService
    {
        private readonly IRepository<UserPermission> _userPermissionRepository;
        private readonly IRepository<Permission> _permissionRepository;

        private CheckPermissionService(
            IRepository<UserPermission> userPermissionRepository,
            IRepository<Permission> permissionRepository)
        {
            _userPermissionRepository = userPermissionRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<bool> CheckUserPermission(int userId, string permissionName)
        {
            var userPermission = await _userPermissionRepository.GetFirstWhereAsync(
                up => up.UserId == userId && up.PermissionName == permissionName
            );
            return userPermission != null;
        }

        public string GetPermissionNameFromMethod(string methodName)

        {
            var IgnoreWords = new List<string> { "Async" };
            foreach (string IngoreWord in IgnoreWords )
            {
                methodName = methodName.Replace(IngoreWord, "");
            }
            return methodName;
        }

        // Add other methods as needed
    }
}
