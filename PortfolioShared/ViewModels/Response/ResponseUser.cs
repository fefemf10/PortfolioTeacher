namespace PortfolioShared.ViewModels.Response
{
	public record ResponseUser(Guid Guid, string Email, string AccessToken, string RefreshToken, bool IsAuthenticated);
}
