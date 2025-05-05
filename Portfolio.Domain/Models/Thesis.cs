namespace Portfolio.Domain.Models
{
    public class Thesis : Publication
    {
        public string Type {  get; set; }
        public string Collection {  get; set; }
        public int BeginPage { get; set; }
        public int EndPage { get; set; }
        public string Place {  get; set; }
        public DateOnly DateEvent { get; set; }
        public int CountPages { get; set; }
    }
}
