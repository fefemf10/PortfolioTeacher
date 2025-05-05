namespace Portfolio.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public bool Gender { get; set; }
        public DateOnly? DateBirthday { get; set; }
        public string Phone { get; set; }
        public Guid? AvatarId { get; set; }
        public UserFile? Avatar { get; set; }
        public List<Post> Posts { get; set; }
        public List<Work> Works { get; set; }
        public List<University> Universities { get; set; }
    }
}
