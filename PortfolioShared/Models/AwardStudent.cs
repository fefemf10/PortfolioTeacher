namespace PortfolioShared.Models
{
	public class AwardStudent
	{
		public int Id { get; set; }
		public Guid? TeacherId { get; set; }
		public Teacher? Teacher { get; set; }
		public Guid? StudentId { get; set; }
		public Student? Student { get; set; }
		public required string Name { get; set; }
		public DateOnly? DateAward { get; set; }
	}
}
