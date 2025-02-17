namespace Portfolio.Domain.Models
{
	public class ScienceProject
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
        public DateOnly BeginTimeWork { get; set; }
        public DateOnly? EndTimeWork { get; set; }
        public bool Director { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
