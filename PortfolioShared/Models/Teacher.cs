namespace PortfolioShared.Models
{
    public class Teacher : User
    {
        public string? Post { get; set; }
        public string? AcademicDegree { get; set; }
        public string? AcademicTitle { get; set; }
		public Guid FacultyId { get; set; }
		public Faculty Faculty { get; set; }
		public Guid? DepartmentId { get; set; }
		public Department? Department { get; set; }
		public List<Work> Works { get; set; } = new();
		public List<University> Universities { get; set; } = new();
		public List<ScienceProject> ScienceProjects { get; set; } = new();
        public List<Discipline> Disciplines { get; set; } = new();
        public List<Publication> Publications { get; set; } = new();
		public List<Award> Awards { get; set; } = new();
		public List<AwardStudent> AwardStudents { get; set; } = new();
		public List<Dissertation> Dissertations { get; set; } = new();
		public List<ProfessionalDevelopment> ProfessionalDevelopments { get; set; } = new();
		public List<PublicActivity> PublicActivities { get; set; } = new();
		public byte[]? Image { get; set; }
    }
}
