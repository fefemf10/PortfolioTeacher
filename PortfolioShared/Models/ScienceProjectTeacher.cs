namespace PortfolioShared.Models
{
	public class ScienceProjectTeacher
	{
		public int Id { get; set; }
		public int TeacherId { get; set; }
		public int ScienceProjectId { get; set; }
		public DateOnly BeginTimeWork { get; set; }
		public DateOnly EndTimeWork { get; set; }
		public bool Director { get; set; }
	}
}
