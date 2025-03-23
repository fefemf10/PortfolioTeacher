using AutoMapper;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;

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
            CreateMap<Domain.Models.Work, ResponseWork>();
            CreateMap<Domain.Models.University, ResponseUniversity>();
            CreateMap<Domain.Models.Award, ResponseAward>();
            CreateMap<Domain.Models.PublicActivity, ResponsePublicActivity>();
            CreateMap<Domain.Models.Publication, ResponsePublication>();
            CreateMap<Domain.Models.ScienceProject, ResponseScienceProject>();
            CreateMap<Domain.Models.ProfessionalDevelopment, ResponseProfessionalDevelopment>();
            CreateMap<Domain.Models.Dissertation, ResponseDissertation>();

            CreateMap<Domain.Models.Teacher, ResponseTeacher>()
                .ForMember(dst => dst.PublicationCount, opt => opt.MapFrom(src => src.Publications.Count));
                //.ConstructUsing(src => new ResponseTeacher(
                //    src.Id,
                //    src.Email,
                //    src.LastName,
                //    src.FirstName,
                //    src.MiddleName,
                //    src.DateBirthday,
                //    src.Post,
                //    src.AcademicDegree,
                //    src.AcademicTitle,
                //    new ResponseFaculty(src.Faculty.Id, src.Faculty.Name, src.Faculty.FullName),
                //    src.Department != null ? new ResponseDepartment(src.Department.Id, src.Department.Name) : null,
                //    (uint)src.Publications.Count
                //));
            //.IncludeMembers(dest => dest.Faculty)
            //.IncludeMembers(dest => dest.Department);
            //.ForCtorParam("Faculty", opt => opt.MapFrom(src => src.Faculty))
            //.ForCtorParam("Department", opt => opt.MapFrom(src => src.Department));

            CreateMap<RequestAddDepartment, Domain.Models.Department>();
            CreateMap<RequestUpdateDepartment, Domain.Models.Department>();
            CreateMap<RequestAddDiscipline, Domain.Models.Discipline>();
            CreateMap<RequestUpdateDiscipline, Domain.Models.Discipline>();

            CreateMap<RequestTeacher, Domain.Models.Teacher>();
            CreateMap<RequestAddTeacher, Domain.Models.Teacher>();
            CreateMap<RequestUniversity, Domain.Models.University>();
            CreateMap<RequestWork, Domain.Models.Work>();
            CreateMap<RequestAward, Domain.Models.Award>();
            CreateMap<RequestScienceProject, Domain.Models.ScienceProject>();
            CreateMap<RequestPublicActivity, Domain.Models.PublicActivity>();
            CreateMap<RequestPublication, Domain.Models.Publication>();
            CreateMap<RequestDissertation, Domain.Models.Dissertation>();

        }
    }
}
