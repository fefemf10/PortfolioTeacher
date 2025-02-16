namespace Portfolio.Domain.Models
{
    public class Publication
    {
        public Guid Id { get; set; }
		public string Name { get; set; }
        public string Form { get; set; }
        public string OutputData { get; set; }
        public uint Size { get; set; }
        public string? CoAuthor { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
