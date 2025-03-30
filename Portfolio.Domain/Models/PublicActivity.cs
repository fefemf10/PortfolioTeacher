using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public class PublicActivity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
    }
}
