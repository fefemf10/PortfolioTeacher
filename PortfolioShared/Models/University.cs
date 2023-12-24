namespace PortfolioShared.Models
{
    public class University
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Specialization { get; set; }
        public required string Qualification { get; set; }
        public required int YearGraduation { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
	}
}
