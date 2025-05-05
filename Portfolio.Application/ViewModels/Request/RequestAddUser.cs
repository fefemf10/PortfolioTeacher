using Portfolio.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
{
	public class RequestAddUser
	{
        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
        public string LastName { get; set; }
        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
		[Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		[EmailAddress(ErrorMessageResourceName = "EmailError", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public string Email { get; set; }
		[Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		[MinLength(5, ErrorMessageResourceName = "PasswordLength", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		public Roles Role { get; set; }
		[Required]
		public Guid ParentDepartmentId { get; set; }
        [Required]
        public Guid? DepartmentId { get; set; }
	}
}
