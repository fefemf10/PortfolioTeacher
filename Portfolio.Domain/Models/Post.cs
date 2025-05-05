using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public enum PostType
    {
        None,
        Laborant,
        Engineer,
        Assistant,
        Teacher,
        SeniorTeacher,
        Deputy,
        Docent,
        Professor,
        Dean,
        Specialist,
        Manager,
        AssociateDirector,
        Director,
        Rector
    }
    public class Post
    {
        public Guid Id { get; set; }
        public PostType PostType { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
    }
}
