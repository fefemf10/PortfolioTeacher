using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Request
{
    public class RequestTeacher
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateBirthday { get; set; }
        public string? Post { get; set; }
        public string? AcademicDegree { get; set; }
        public string? AcademicTitle { get; set; }
		[Required]
		public Guid DepartmentId { get; set; }
	}
}
