namespace PortfolioServer.Models
{
    public class UniversityTeacher
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int UniversityId { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public int YearGraduation { get; set; }
    }
}
