namespace Portfolio.Domain.Models
{
    public class Teacher : User
    {
        public string Post { get; set; }
        public string? AcademicDegree { get; set; }
        public string? AcademicTitle { get; set; }
		public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
		public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
		public ICollection<ScienceProject> ScienceProjects { get; private set; }
        public ICollection<Discipline> Disciplines { get; private set; }
        public ICollection<Publication> Publications { get; private set; }
		public ICollection<Award> Awards { get; private set; }
		public ICollection<AwardStudent> AwardStudents { get; private set; }
		public ICollection<Dissertation> Dissertations { get; private set; }
		public ICollection<ProfessionalDevelopment> ProfessionalDevelopments { get; private set; }
		public ICollection<PublicActivity> PublicActivities { get; private set; }
    }
}
