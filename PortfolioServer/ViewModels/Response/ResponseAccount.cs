using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.ViewModels.Response
{
    public class ResponseAccount
    {
		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
	}
}
