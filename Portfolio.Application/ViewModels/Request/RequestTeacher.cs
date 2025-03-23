using Portfolio.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
{
    public class RequestTeacher
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateOnly? DateBirthday { get; set; }
        [Required]
        public Post Post { get; set; }
        [Required]
        public AcademicDegree AcademicDegree { get; set; }
        [Required]
        public AcademicTitle AcademicTitle { get; set; }
        [Required]
        public Guid FacultyId { get; set; }
        public Guid? DepartmentId { get; set; }
        [Required]
        public uint PublicationCount { get; set; }
	}
}