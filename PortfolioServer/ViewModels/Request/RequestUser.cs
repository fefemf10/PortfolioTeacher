using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.ViewModels.Request
{
	public class RequestUser
	{
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
		[Required]
		public bool? Teacher { get; set; }
	}
}
