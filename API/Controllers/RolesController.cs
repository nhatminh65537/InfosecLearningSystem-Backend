using InfosecLearningSystem_Backend.Controllers;
using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Application.Services;
using InfosecLearningSystem_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfosecLearningSystem_Backend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _dataService;
        public RolesController(IRoleService serviceProvider)
        {
            _dataService = serviceProvider;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _dataService.GetAllRolesAsync());
        }

        [HttpGet("{roleName}")]
        public async Task<ActionResult> Get(string roleName)
        {
            return Ok(await _dataService.GetRoleByNameAsync(roleName));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RoleDTO roleDTO)
        {
            await _dataService.AddRoleAsync(roleDTO);
            return CreatedAtAction(nameof(Get), new { roleName = roleDTO.Name }, roleDTO);
        }

        [HttpPut("{roleName}")]
        public async Task<ActionResult> Update(string roleName, [FromBody] RoleDTO roleDTO)
        {
            if (roleDTO.Name != roleName)
            {
                return BadRequest();
            }
            await _dataService.UpdateRoleAsync(roleDTO);
            return NoContent();
        }

        [HttpDelete("{roleName}")]
        public async Task<ActionResult> Delete(string roleName)
        {
            await _dataService.DeleteRoleAsync(roleName);
            return NoContent();
        }

        [HttpGet("{roleName}/permissions")]
        public async Task<ActionResult> GetPermissions(string roleName)
        {
            var permissions = await _dataService.GetPermissionsInRoleAsync(roleName);
            return Ok(permissions);
        }

        [HttpPost("{roleName}/permissions/{permissionName}")]
        public async Task<ActionResult> AddPermission(string roleName, string permissionName)
        {
            await _dataService.AddPermissionToRoleAsync(roleName, permissionName);
            return NoContent();
        }

        [HttpDelete("{roleName}/permissions/{permissionName}")]
        public async Task<ActionResult> RemovePermission(string roleName, string permissionName)
        {
            await _dataService.RemovePermissionFromRoleAsync(roleName, permissionName);
            return NoContent();
        }
    }
}
