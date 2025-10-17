using AutoMapper;

namespace CMEManagementService.Mappers
{
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {
            CreateMap<Models.DTO.CreateDoctorDTO, Models.Entites.Doctor>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty))
                .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
                .ReverseMap();
        }
    }
}