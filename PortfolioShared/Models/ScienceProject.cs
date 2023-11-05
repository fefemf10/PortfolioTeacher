namespace PortfolioShared.Models
{
	public class ScienceProject
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public List<Teacher> Teachers { get; set; }
	}
}
