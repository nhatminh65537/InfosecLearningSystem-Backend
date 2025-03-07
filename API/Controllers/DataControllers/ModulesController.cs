using InfosecLearningSystem_Backend.Controllers;
using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfosecLearningSystem_Backend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModulesController : DataController<ModuleDTO>
    {
        public ModulesController(IDataService<ModuleDTO> serviceProvider) 
            : base(serviceProvider)
        {
        }
    }
}
