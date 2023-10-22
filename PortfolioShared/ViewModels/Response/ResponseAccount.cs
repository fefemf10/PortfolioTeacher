using System.ComponentModel.DataAnnotations;

namespace PortfolioShared.ViewModels.Response
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
