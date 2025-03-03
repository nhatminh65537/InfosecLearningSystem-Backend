using AutoMapper;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend.Domain.MappingProfiles
{
    public class SystemConfigMappingProfile : Profile
    {
        public SystemConfigMappingProfile()
        {
            CreateMap<SystemConfig, SystemConfigDTO>().ReverseMap();
        }
    }
}
