namespace PortfolioShared.Models
{
    public class Teacher : User
    {
        public string Post { get; set; }
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
        public List<Work> Works { get; set; }
        public List<University> Universities { get; set; }
        public List<ScienceProject> ScienceProjects { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<Publication> Publications { get; set; }
        public List<Award> Awards { get; set; }
        public List<AwardStudent> AwardStudents { get; set; }
        public List<Dissertation> Dissertations { get; set; }
        public List<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
        public byte[] Image { get; set; }
    }
}
