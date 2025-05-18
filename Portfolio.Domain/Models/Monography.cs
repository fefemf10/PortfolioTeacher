namespace Portfolio.Domain.Models
{
    public class Monography : Publication
    {
        public Monography() { PublicationType = PublicationType.Monography; }
        public string? Publisher { get; set; }
        public int Circulation { get; set; }
        public int CountPages { get; set; }
    }
}
