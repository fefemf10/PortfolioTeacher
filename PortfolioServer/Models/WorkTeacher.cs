namespace PortfolioServer.Models
{
    public class WorkTeacher
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int WorkId { get; set; }
        public string Post { get; set; }
        public DateOnly BeginTimeWork { get; set; }
        public DateOnly EndTimeWork { get; set; }
    }
}
