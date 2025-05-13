namespace Portfolio.Domain.Models
{
    public class Teacher : User
    {
        public AcademicDegree AcademicDegree { get; set; }
        public AcademicTitle AcademicTitle { get; set; }
		public List<ScienceProject> ScienceProjects { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<Dissertation> Dissertations { get; set; }
        public List<Publication> Publications { get; set; }
		public List<Award> Awards { get; set; }
		public List<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
		public List<PublicActivity> PublicActivities { get; set; }
    }
}
