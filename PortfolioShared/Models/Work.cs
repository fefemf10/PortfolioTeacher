namespace PortfolioShared.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
