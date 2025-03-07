using InfosecLearningSystem_Backend.Domain.Interfaces;
using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;


namespace InfosecLearningSystem_Backend.Application.Authorization
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IRepository<UserPermissionView> _userPermissionViewRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionHandler(IRepository<UserPermissionView> userPermissionViewRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userPermissionViewRepository = userPermissionViewRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                context.Fail();
                return;
            }

            if (!int.TryParse(userIdClaim, out int userId))
            {
                throw new InvalidOperationException("User ID is invalid.");
            }

            
            var hasPermission = await _userPermissionViewRepository.GetFirstWhereAsync(upv => upv.UserId == userId && upv.PermissionName == requirement.Permission);
            if (hasPermission != null)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
