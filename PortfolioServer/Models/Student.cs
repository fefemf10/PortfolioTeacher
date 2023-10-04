namespace PortfolioServer.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public List<AwardStudent> AwardStudents { get; set; }
	}
}
