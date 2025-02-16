using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
{
	public class RequestAddTeacher
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Role { get; set; }
		[Required]
		public Guid FacultyId { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
	}
}
