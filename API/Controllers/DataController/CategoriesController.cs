using InfosecLearningSystem_Backend.Controllers;
using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfosecLearningSystem_Backend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : DataController<CategoryDTO>
    {
        public CategoryController(IDataService<CategoryDTO> serviceProvider) 
            : base(serviceProvider)
        {
        }
    }
}
