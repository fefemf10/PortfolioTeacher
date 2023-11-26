namespace PortfolioShared.Models
{
    public class Work
    {
        public int Id { get; set; }
        public required string Name { get; set; }
		public required string Post { get; set; }
		public required DateOnly BeginTimeWork { get; set; }
		public DateOnly? EndTimeWork { get; set; }
		public Guid? TeacherId { get; set; }
		public Teacher? Teacher { get; set; }
	}
}
