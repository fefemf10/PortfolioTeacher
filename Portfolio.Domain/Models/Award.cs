using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public class Award
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameOrganization { get; set; }
        public DateOnly? DateAward { get; set; }
        public Guid TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
    }
}
