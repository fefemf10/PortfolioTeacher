using System.Text.Json.Serialization;

namespace PortfolioShared.Models
{
	public class Faculty
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string FullName { get; set; }
		[JsonIgnore]
		public List<Department> Departments { get; set; } = new();
	}
}
