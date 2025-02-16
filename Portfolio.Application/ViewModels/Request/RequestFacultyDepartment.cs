namespace Portfolio.Application.ViewModels.Request
{
	public class RequestFacultyDepartment
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string FullName { get; set; }
		public List<RequestUpdateDepartment> Departments { get; set; }
	}
}
