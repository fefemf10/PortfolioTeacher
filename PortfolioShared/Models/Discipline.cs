using System.Text.Json.Serialization;

namespace PortfolioShared.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public List<Teacher> Teachers { get; set; }
    }
}
