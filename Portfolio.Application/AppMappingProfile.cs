using AutoMapper;
using Portfolio.Domain.Models;

namespace Portfolio.Application
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Award, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.DateAward.Year));
            CreateMap<Dissertation, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.YearProtection.Year));
            CreateMap<Work, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.BeginTimeWork.Year));
            CreateMap<University, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.YearGraduation));
            CreateMap<ScienceProject, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.BeginTimeWork.Year));
            CreateMap<ProfessionalDevelopment, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.DateСompletion.Year));

        }
    }
}
