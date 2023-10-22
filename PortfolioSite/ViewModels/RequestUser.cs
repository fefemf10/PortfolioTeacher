using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
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
