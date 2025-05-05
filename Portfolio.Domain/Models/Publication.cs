using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public enum PublicationType
    {
        Thesis,
        Article,
        Monography,
        Dissertation
    }
    public class Publication
    {
        public Guid Id { get; set; }
		public string Name { get; set; }
        public PublicationType PublicationType { get; protected set; }
        public int YearPublication { get; set; }
        public List<Teacher> CoAuthors { get; set; } = new();
        public List<UserFile> Files { get; set; } = new();
    }
}
