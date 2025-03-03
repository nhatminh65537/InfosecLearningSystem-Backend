using AutoMapper;
using InfosecLearningSystem_Backend.Domain.Models;
using InfosecLearningSystem_Backend.Domain.DTOs;

namespace InfosecLearningSystem_Backend.Domain.MappingProfiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
