using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
	public class Department
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
        public Guid FacultyId { get; set; }
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        [JsonIgnore]
        public ICollection<Teacher> Teachers { get; private set; }
	}
}
