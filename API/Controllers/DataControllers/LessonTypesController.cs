using InfosecLearningSystem_Backend.Controllers;
using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfosecLearningSystem_Backend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LessonTypesController : DataController<LessonTypeDTO>
    {
        public LessonTypesController(IDataService<LessonTypeDTO> serviceProvider) 
            : base(serviceProvider)
        {
        }
    }
}
