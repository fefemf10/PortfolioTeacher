﻿namespace PortfolioServer.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameOrganization { get; set; }
        public DateOnly DateAward { get; set; }
    }
}