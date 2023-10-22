namespace PortfolioShared.Models
{
    public class Dissertation
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Name { get; set; }
        public DateOnly YearProtection { get; set; }
    }
}
