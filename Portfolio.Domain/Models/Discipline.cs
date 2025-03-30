using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public class Discipline
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; private set; }
    }
}
