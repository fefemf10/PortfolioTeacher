namespace PortfolioServer.Models
{
    public class WorkTeacher
    {
        public int IdTeacher { get; set; }
        public int IdWork { get; set; }
        public string Post { get; set; }
        public DateOnly BeginTimeWork { get; set; }
        public DateOnly EndTimeWork { get; set; }
    }
}
