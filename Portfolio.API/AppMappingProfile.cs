using AutoMapper;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;

namespace Portfolio.API
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Domain.Models.User, ResponseUser>();
            CreateMap<Domain.Models.Faculty, ResponseFaculty>();
            CreateMap<Domain.Models.Department, ResponseDepartment>();
            CreateMap<Domain.Models.Faculty, ResponseFacultyDepartments>();
            CreateMap<Domain.Models.Discipline, ResponseDiscipline>();
            
            CreateMap<Domain.Models.Teacher, ResponseTeacher>()
                .ForMember(dest => dest.PublicationCount, opt => opt.MapFrom(scr => scr.PublicActivities.Count));

            CreateMap<RequestAddDepartment, Domain.Models.Department>();
            CreateMap<RequestUpdateDepartment, Domain.Models.Department>();
            CreateMap<RequestAddDiscipline, Domain.Models.Discipline>();
            CreateMap<RequestUpdateDiscipline, Domain.Models.Discipline>();

            CreateMap<RequestTeacher, Domain.Models.Teacher>();
            CreateMap<RequestAddTeacher, Domain.Models.Teacher>();
        }
    }
}
