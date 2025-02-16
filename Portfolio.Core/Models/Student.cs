namespace Portfolio.Domain.Models
{
    public class Student : User
	{
		public ICollection<AwardStudent> AwardStudents { get; private set; }
	}
}
