using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
	public class ScienceProject
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
        public DateOnly BeginTimeWork { get; set; }
        public DateOnly? EndTimeWork { get; set; }
        public bool Director { get; set; }
        public Guid TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
    }
}
