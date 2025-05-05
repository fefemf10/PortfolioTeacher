using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
	public class University
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Specialization { get; set; }
		public string Qualification { get; set; }
		public int YearGraduation { get; set; }
		public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
	}
}
