﻿namespace PortfolioShared.Models
{
    public class ProfessionalDevelopmentTeacher
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid ProfessionalDevelopmentId { get; set; }
    }
}
