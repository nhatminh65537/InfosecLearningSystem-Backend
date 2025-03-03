using AutoMapper;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend.Domain.MappingProfiles
{
    public class LessonTypeMappingProfile : Profile
    {
        public LessonTypeMappingProfile()
        {
            CreateMap<LessonType, LessonTypeDTO>().ReverseMap();
        }
    }
}
