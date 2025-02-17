namespace Portfolio.Domain.Models
{
	public class Department
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
        public Guid FacultyId { get; set; }
		public Faculty Faculty { get; set; }
		public ICollection<Teacher> Teachers { get; private set; }
	}
}
