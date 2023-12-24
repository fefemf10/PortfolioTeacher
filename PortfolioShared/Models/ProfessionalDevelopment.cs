namespace PortfolioShared.Models
{
    public class ProfessionalDevelopment
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string NameOrganization { get; set; }
        public required string NameDocument { get; set; }
        public string? SeriaDocument { get; set; }
        public string? NumberDocument { get; set; }
        public DateOnly? DateСompletion { get; set; }
        public int? ListeningTime { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
	}
}