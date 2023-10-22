using System.ComponentModel.DataAnnotations;

namespace PortfolioShared.ViewModels.Request
{
	public class RequestLogin
	{
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
	}
}
