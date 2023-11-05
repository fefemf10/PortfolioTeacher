namespace PortfolioShared.ViewModels.Response
{
	public record ResponseUser(Guid Id, string Email, string? FirstName, string? MiddleName, string? LastName, DateOnly? DateBirthday);
}
