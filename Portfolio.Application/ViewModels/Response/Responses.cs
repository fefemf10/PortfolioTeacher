using Portfolio.Domain.Models;

namespace Portfolio.Application.ViewModels.Response
{
    public record ResponseFaculty(Guid Id, string Name, string FullName);
    public record ResponseDepartment(Guid Id, string Name);
    public record ResponseFacultyDepartments(Guid Id, string Name, string FullName, List<ResponseDepartment> Departments);
    public record ResponseAddDepartment(string Name, Guid FaculyId);
    public record ResponseDiscipline(Guid Id, string Name);
    public record ResponseUser(Guid Id, string Email, string LastName, string FirstName, string? MiddleName, string Gender, DateOnly? DateBirthday, string Phone);
    //public record ResponseTeacher(Guid Id, string Email, string LastName, string FirstName, string? MiddleName, DateOnly? DateBirthday, Post Post, AcademicDegree AcademicDegree, AcademicTitle AcademicTitle, ResponseFaculty Faculty, ResponseDepartment? Department, uint PublicationCount);
    public record ResponseRegistration(Guid Guid, string Email, string AccessToken, string RefreshToken);
    public record ResponseLogin(Guid Guid, string Email, string AccessToken, string RefreshToken);
    public record ResponseAccount(string FirstName, string LastName, string Email, string Password);
    public record ResponseAward(Guid Id, string Name, string NameOrganization, DateOnly? DateAward);
    public record ResponseDissertation(Guid Id, string Name, DateOnly YearProtection);
    public record ResponseProfessionalDevelopment(Guid Id, string Name, string NameOrganization, string NameDocument, string? SeriaDocument, string? NumberDocument, DateOnly? DateСompletion, int? ListeningTime);
    public record ResponsePublicActivity(Guid Id, string Name);
    public record ResponsePublication(Guid Id, string Name, string? Form, string? OutputData, uint Size, string? CoAuthor);
    public record ResponseScienceProject(Guid Id, string Name, DateOnly BeginTimeWork, DateOnly? EndTimeWork, bool Director);
    public record ResponseUniversity(Guid Id, string Name, string Specialization, string Qualification, int YearGraduation);
    public record ResponseWork(Guid Id, string Name, string Post, DateOnly BeginTimeWork, DateOnly? EndTimeWork);
}
