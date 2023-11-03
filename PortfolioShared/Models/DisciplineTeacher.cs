namespace PortfolioShared.Models
{
    public class DisciplineTeacher
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public int DisciplineId { get; set; }
    }
}
