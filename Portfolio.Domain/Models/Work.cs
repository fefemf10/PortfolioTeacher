using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public class Work
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
		public string Post { get; set; }
		public DateOnly BeginTimeWork { get; set; }
		public DateOnly? EndTimeWork { get; set; }
		public Guid TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
	}
}
