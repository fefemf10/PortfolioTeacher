namespace PortfolioShared.Models
{
    public class Dissertation
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateOnly YearProtection { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}
