namespace PortfolioShared.Models
{
    public class Dissertation
    {
        public int Id { get; set; }
        public Guid ?TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public required string Name { get; set; }
        public required DateOnly YearProtection { get; set; }
    }
}
