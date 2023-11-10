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
        public string? Email { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? MiddleName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateOnly? DateBirthday { get; set; }
        [Required]
        public string? Post { get; set; }
        [Required]
        public string? AcademicDegree { get; set; }
        [Required]
        public string? AcademicTitle { get; set; }
    }
}
