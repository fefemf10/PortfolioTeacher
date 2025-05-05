using Portfolio.Domain.Models;
using System.Collections.Generic;

namespace Portfolio.Application.ViewModels.Response
{
    public record ResponsePost(Guid id, PostType PostType, Guid UserId, Guid DepartmentId);
    public record ResponseDepartment(Guid Id, string Name, string? ShortName, DepartmentType DepartmentType, List<ResponseDepartment> ChildDepartments, Guid? ParentDepartmentId);
    public record ResponseDiscipline(Guid Id, string Name);
    public record ResponseAward(Guid Id, string Name, string NameOrganization, DateOnly? DateAward);
    public record ResponseProfessionalDevelopment(Guid Id, string Name, string NameOrganization, string NameDocument, string? SeriaDocument, string? NumberDocument, DateOnly? DateСompletion, int? ListeningTime);
    public record ResponsePublicActivity(Guid Id, string Name);
    public record ResponseScienceProject(Guid Id, string Name, DateOnly BeginTimeWork, DateOnly? EndTimeWork, bool Director);
    public record ResponseUniversity(Guid Id, string Name, string Specialization, string Qualification, int YearGraduation);
    public record ResponseWork(Guid Id, string Name, string Post, DateOnly BeginTimeWork, DateOnly? EndTimeWork);
    public record ResponseTeacherShort(Guid Id, string LastName, string FirstName, string? MiddleName);
    public record ResponsePublication(Guid Id, string Name, PublicationType PublicationType, int YearPublication, List<ResponseTeacherShort> CoAuthors, List<UserFile> Files);
    public record ResponseDissertation(Guid Id, string Name, PublicationType PublicationType, int YearPublication, List<ResponseTeacherShort> CoAuthors, List<UserFile> Files) : ResponsePublication(Id, Name, PublicationType, YearPublication, CoAuthors, Files);
    public record ResponseMonography(Guid Id, string Name, PublicationType PublicationType, int YearPublication, List<ResponseTeacherShort> CoAuthors, List<UserFile> Files, string? Publisher, int Сirculation, int CountPages) : ResponsePublication(Id, Name, PublicationType, YearPublication, CoAuthors, Files);
    public record ResponseArticle(Guid Id, string Name, PublicationType PublicationType, int YearPublication, List<ResponseTeacherShort> CoAuthors, List<UserFile> Files, string? Journal, int IssueNumber, int PrintedSheets, int BeginPage, int EndPage, string? URL) : ResponsePublication(Id, Name, PublicationType, YearPublication, CoAuthors, Files);
    public record ResponseThesis(Guid Id, string Name, PublicationType PublicationType, int YearPublication, List<ResponseTeacherShort> CoAuthors, List<UserFile> Files, string Type, string Collection, int BeginPage, int EndPage, string Place, DateOnly DateEvent, int CountPages) : ResponsePublication(Id, Name, PublicationType, YearPublication, CoAuthors, Files);
    public class ResponseUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public bool Gender { get; set; }
        public DateOnly? DateBirthday { get; set; }
        public string Phone { get; set; }
        public UserFile Avatar { get; set; }
        public List<ResponsePost> Posts { get; set; }
    }
    public class ResponseTeacher : ResponseUser
    {
        public AcademicDegree AcademicDegree { get; set; }
        public AcademicTitle AcademicTitle { get; set; }
        public int PublicationCount { get; set; }
    }
}
