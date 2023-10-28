namespace PortfolioShared.ViewModels.Response
{
	public record ResponseUser(string FirstName, string MiddleName, string LastName, DateOnly DateBirthday, string Email);
}
