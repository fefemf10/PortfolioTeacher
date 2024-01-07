namespace PortfolioShared.ViewModels.Request
{
	public class RequestFacultyDepartment
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string FullName { get; set; }
		public List<RequestDepartment> Departments { get; set; }
	}
}
