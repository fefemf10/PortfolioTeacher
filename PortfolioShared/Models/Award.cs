namespace PortfolioShared.Models
{
    public class Award
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Name { get; set; }
        public string NameOrganization { get; set; }
        public DateOnly DateAward { get; set; }
    }
}
