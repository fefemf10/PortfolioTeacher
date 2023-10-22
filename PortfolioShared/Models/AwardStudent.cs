namespace PortfolioShared.Models
{
	public class AwardStudent
	{
		public int Id { get; set; }
		public int TeacherId { get; set; }
		public Teacher Teacher { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public string Name { get; set; }
		public DateOnly DateAward { get; set; }
	}
}
