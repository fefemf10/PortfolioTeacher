using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PortfolioShared.ViewModels.Request
{
	public class RequestRegistration
	{
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		[Required]
		public string? Password { get; set; }
		[Required]
		[JsonIgnore]
		[Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
		public string? ConfirmPassword { get; set; }
		[Required]
		public bool? Teacher { get; set; } = true;
	}
}
