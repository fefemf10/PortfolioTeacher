﻿namespace PortfolioShared.Models
{
    public class Award
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string NameOrganization { get; set; }
        public DateOnly? DateAward { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}
