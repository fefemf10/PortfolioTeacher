using System.Text.Json.Serialization;

namespace PortfolioShared.Models
{
	public class Department
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
        public Guid FacultyId { get; set; }
		[JsonIgnore]
		public Faculty Faculty { get; set; }
        [JsonIgnore]
        public List<Teacher> Teachers { get; set; } = new();
	}
}
