namespace Portfolio.Domain.Models
{
    public class Teacher : User
    {
        public Post Post { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public AcademicTitle AcademicTitle { get; set; }
		public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
		public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
		public ICollection<ScienceProject> ScienceProjects { get; set; }
        public ICollection<Discipline> Disciplines { get; set; }
        public ICollection<Publication> Publications { get; set; }
		public ICollection<Award> Awards { get; set; }
		public ICollection<AwardStudent> AwardStudents { get; set; }
		public ICollection<Dissertation> Dissertations { get; set; }
		public ICollection<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
		public ICollection<PublicActivity> PublicActivities { get; set; }
    }
}
