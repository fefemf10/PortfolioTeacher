using PortfolioShared.ViewModels.Request;

namespace PortfolioShared.ViewModels.Response
{
	public record ResponseTeacher(Guid Id, string Email, string? FirstName, string? MiddleName, string? LastName, DateOnly? DateBirthday, string? Post, string? AcademicDegree, string? AcademicTitle, RequestFaculty Faculty, RequestDepartment? Department, uint PublicationCount);
}
