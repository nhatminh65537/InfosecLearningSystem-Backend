using InfosecLearningSystem_Backend.Domain.DTOs;
using InfosecLearningSystem_Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfosecLearningSystem_Backend.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _dataService;
        public UserController(IUserService serviceProvider)
        {
            _dataService = serviceProvider;
        }
    }
}
