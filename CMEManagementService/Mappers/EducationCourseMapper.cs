using AutoMapper;
using CMEManagementService.Models.DTO;
using CMEManagementService.Models.Entites;

namespace CMEManagementService.Mappers
{
    public class EducationCourseMapper : Profile
    {
        public EducationCourseMapper()
        {
            CreateMap<CreateEducationCourseDTO, EducationCourse>()
                .ForMember(dest => dest.EducationCourseId, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}