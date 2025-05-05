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
		public string LastName { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		[Required]
		public byte Gender {  get; set; }
        [Required]
		[Phone]
        public string Phone { get; set; }
	}
}
