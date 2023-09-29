namespace PortfolioServer.Models
{
    public class Dissertation
    {
        public int Id { get; set; }
        public int IdTeacher { get; set; }
        public DateOnly YearProtection { get; set; }
        public string Name { get; set; }
    }
}
