namespace Portfolio.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public DateOnly? DateBirthday { get; set; }
        public ICollection<Work> Works { get; private set; }
        public ICollection<University> Universities { get; private set; }
    }
}
