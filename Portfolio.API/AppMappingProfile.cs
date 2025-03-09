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

            CreateMap<Domain.Models.Teacher, ResponseTeacher>()
                .ConstructUsing(src => new ResponseTeacher(
                    src.Id,
                    src.Email,
                    src.LastName,
                    src.FirstName,
                    src.MiddleName,
                    src.DateBirthday,
                    src.Post,
                    src.AcademicDegree,
                    src.AcademicTitle,
                    new ResponseFaculty(src.Faculty.Id, src.Faculty.Name, src.Faculty.FullName),
                    src.Department != null ? new ResponseDepartment(src.Department.Id, src.Department.Name) : null,
                    (uint)src.Publications.Count
                ));
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

        }
    }
}
