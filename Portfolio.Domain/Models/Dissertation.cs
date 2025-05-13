using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public enum DissertationType
    {
        None,
        Master,
        Candidate,
        Doctor
    }
    public class Dissertation
    {
        public Guid Id { get; set; }
        public DissertationType Type { get; set; }
        public int YearProtection { get; set; }
        public string Topic { get; set; }
        public string Specialization { get; set; }
        public Guid TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }
    }
}
