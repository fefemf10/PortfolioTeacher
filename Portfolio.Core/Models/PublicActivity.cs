namespace Portfolio.Domain.Models
{
    public class PublicActivity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
