using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public enum DepartmentType
    {
        Department,
        Faculty,
        Service,
        School,
        Branch,
        Rectorate
    }
	public class Department
	{
		public Guid Id { get; set; } = Guid.NewGuid();
        public DepartmentType DepartmentType { get; set; }
        public string Name { get; set; }
        public string? ShortName { get; set; }
        public Guid? ParentDepartmentId { get; set; }
        [JsonIgnore]
        public Department? ParentDepartment { get; set; }
        [JsonIgnore]
        public ICollection<Department> ChildDepartments { get; set; }
        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }
	}
}
