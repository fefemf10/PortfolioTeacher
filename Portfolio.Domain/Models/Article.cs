namespace Portfolio.Domain.Models
{
    public class Article : Publication
    {
        public Article() { PublicationType = PublicationType.Article; }
        public string? Journal {  get; set; }
        public int IssueNumber { get; set; }
        public int PrintedSheets { get; set; }
        public int BeginPage { get; set; }
        public int EndPage { get; set; }
        public string? URL { get; set; }
    }
}
