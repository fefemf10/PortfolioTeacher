using Portfolio.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
{
    public class RequestTeacher
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateOnly? DateBirthday { get; set; }
        public Post Post { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public AcademicTitle AcademicTitle { get; set; }
		public Guid FacultyId { get; set; }
		public Guid? DepartmentId { get; set; }
		public uint PublicationCount { get; set; }
	}
}