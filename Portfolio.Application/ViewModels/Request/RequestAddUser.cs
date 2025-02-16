using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.ViewModels.Request
{
	public class RequestAddUser
	{
		[Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		[EmailAddress(ErrorMessageResourceName = "EmailError", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public string Email { get; set; }
		[Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		[MinLength(5, ErrorMessageResourceName = "PasswordLength", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		public string Role { get; set; }
		[Required]
		public Guid FacultyId { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
	}
}
