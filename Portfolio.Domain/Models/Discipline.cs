namespace Portfolio.Domain.Models
{
    public class Discipline
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; private set; }
    }
}
