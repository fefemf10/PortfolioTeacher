namespace PortfolioShared.Models
{
	public class AwardStudent
	{
		public Guid Id { get; set; }
		public Guid StudentId { get; set; }
		public Student Student { get; set; } = null!;
		public required string Name { get; set; }
		public DateOnly? DateAward { get; set; }
		public Guid? TeacherId { get; set; }
		public Teacher? Teacher { get; set; }
	}
}
