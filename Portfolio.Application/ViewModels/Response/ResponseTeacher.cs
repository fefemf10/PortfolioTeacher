using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.ViewModels.Response
{
    public class ResponseTeacher
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public DateOnly? DateBirthday { get; set; }
        public string Phone { get; set; }
        public Post Post { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public AcademicTitle AcademicTitle { get; set; }
        public ResponseFaculty Faculty { get; set; }
        public ResponseDepartment? Department { get; set; }
        public uint PublicationCount { get; set; } 
    }
}
