namespace Portfolio.Domain.Models
{
    public class Dissertation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly YearProtection { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
