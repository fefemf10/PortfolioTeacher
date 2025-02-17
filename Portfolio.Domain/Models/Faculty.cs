namespace Portfolio.Domain.Models
{
	public class Faculty
    {
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string FullName { get; set; }
		public ICollection<Department> Departments { get; private set; }
	}
}
