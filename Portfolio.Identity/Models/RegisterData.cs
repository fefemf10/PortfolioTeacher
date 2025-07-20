using System.ComponentModel.DataAnnotations;

namespace Portfolio.Identity.Models
{
    public class RegisterData
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
