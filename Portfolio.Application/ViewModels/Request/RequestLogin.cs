using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
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
