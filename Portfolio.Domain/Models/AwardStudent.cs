using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
	public class AwardStudent
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateOnly? DateAward { get; set; }
		public Guid? TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
		public Guid StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
	}
}
