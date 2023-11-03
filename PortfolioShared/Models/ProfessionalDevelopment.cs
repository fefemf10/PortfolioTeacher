﻿namespace PortfolioShared.Models
{
    public class ProfessionalDevelopment
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Name { get; set; }
        public string NameOrganization { get; set; }
        public string NameDocument { get; set; }
        public string SeriaDocument { get; set; }
        public string NumberDocument { get; set; }
        public DateOnly DateСompletion { get; set; }
        public int ListeningTime { get; set; }
	}
}