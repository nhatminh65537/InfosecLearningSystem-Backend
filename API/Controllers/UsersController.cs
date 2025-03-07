using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfosecLearningSystem_Backend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _dataService;
        public UsersController(IUserService serviceProvider)
        {
            _dataService = serviceProvider;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _dataService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _dataService.GetUserByIdAsync(id));
        }

        [HttpGet("{id}/profile")]


        // Not add User like this (User AuthController [register] instead)
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO userDTO)
        {
            await _dataService.AddUserAsync(userDTO);
            return CreatedAtAction(nameof(Get), new { id = userDTO.Id }, userDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDTO userDTO)
        {
            if (userDTO.Id != id)
            {
                return BadRequest();
            }
            await _dataService.UpdateUserAsync(userDTO);
            return NoContent();
        }

        // Not delete User like this (User AuthController [unregister] instead)
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _dataService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/permissions")]
        public async Task<ActionResult> GetPermissions(int id)
        {
            var permissions = await _dataService.GetPermissionsOfUserAsync(id);
            return Ok(permissions);
        }

        [HttpPost("{id}/permissions/{permissionName}")]
        public async Task<ActionResult> AddPermission(int id, string permissionName)
        {
            await _dataService.AddPermissionToUserAsync(id, permissionName);
            return NoContent();
        }

        [HttpDelete("{id}/permissions/{permissionName}")]
        public async Task<ActionResult> RemovePermission(int id, string permissionName)
        {
            await _dataService.RemovePermissionFromUserAsync(id, permissionName);
            return NoContent();
        }

        [HttpGet("{id}/roles")]
        public async Task<ActionResult> GetRoles(int id)
        {
            var roles = await _dataService.GetRolesOfUserAsync(id);
            return Ok(roles);
        }

        [HttpPost("{id}/roles/{roleName}")]
        public async Task<ActionResult> AddRole(int id, string roleName)
        {
            await _dataService.AddRoleToUserAsync(id, roleName);
            return NoContent();
        }

        [HttpDelete("{id}/roles/{roleName}")]
        public async Task<ActionResult> RemoveRole(int id, string roleName)
        {
            await _dataService.RemoveRoleFromUserAsync(id, roleName);
            return NoContent();
        }
    }
}
