namespace PortfolioServer.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateOnly DateBirthday { get; set; }
        public string Post { get; set; }
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
    }
}
