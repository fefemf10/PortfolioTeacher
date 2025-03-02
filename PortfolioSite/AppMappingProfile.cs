using AutoMapper;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;

namespace PortfolioSite
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ResponseTeacher, RequestTeacher>();
        }
    }
}
