namespace PortfolioShared.Models
{
    public class Work
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
		public string Post { get; set; }
		public DateOnly BeginTimeWork { get; set; }
		public DateOnly? EndTimeWork { get; set; }
		public Guid TeacherId { get; set; }
		public Teacher Teacher { get; set; } = null!;
	}
}
