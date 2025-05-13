using AutoMapper;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;

namespace Portfolio.Application
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Award, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.DateAward.Year));
            CreateMap<Work, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.BeginTimeWork.Year));
            CreateMap<University, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.YearGraduation));
            CreateMap<ScienceProject, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.BeginTimeWork.Year));
            CreateMap<ProfessionalDevelopment, ShortItem>()
                .ForMember(dst => dst.Year, opt => opt.MapFrom(src => src.DateСompletion.Year));


            CreateMap<Post, ResponsePost>();
            CreateMap<Teacher, ResponseTeacherShort>();

            CreateMap<Publication, ResponsePublication>()
                .Include<Monography, ResponseMonography>()
                .Include<Article, ResponseArticle>()
                .Include<Thesis, ResponseThesis>();

            CreateMap<Dissertation, ResponseDissertation>();
            CreateMap<Monography, ResponseMonography>();
            CreateMap<Article, ResponseArticle>();
            CreateMap<Thesis, ResponseThesis>();

            CreateMap<RequestPublication, Publication>()
                .ForMember(dest => dest.CoAuthors, opt => opt.Ignore())
                .ForMember(dest => dest.Files, opt => opt.Ignore())
                .Include<RequestMonography, Monography>()
                .Include<RequestArticle, Article>()
                .Include<RequestThesis, Thesis>();

            CreateMap<RequestDissertation, Dissertation>();
            CreateMap<RequestMonography, Monography>();
            CreateMap<RequestArticle, Article>();
            CreateMap<RequestThesis, Thesis>();

        }
    }
}
