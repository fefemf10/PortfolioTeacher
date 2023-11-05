using Microsoft.AspNetCore.Identity;

namespace PortfolioShared.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateBirthday { get; set; }
    }
}
