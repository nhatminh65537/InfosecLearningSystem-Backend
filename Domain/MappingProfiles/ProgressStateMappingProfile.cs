using AutoMapper;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend.Domain.MappingProfiles
{
    public class ProgressStateMappingProfile : Profile
    {
        public ProgressStateMappingProfile()
        {
            CreateMap<ProgressState, ProgressStateDTO>().ReverseMap();
        }
    }
}
