using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;
using System.Reflection;

public class ApplicationContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Work> Works { get; set; }
	public DbSet<University> Universities { get; set; }
	public DbSet<ScienceProject> ScienceProjects { get; set; }
	public DbSet<Discipline> Disciplines { get; set; }
	public DbSet<Award> Awards { get; set; }
	public DbSet<Publication> Publications { get; set; }
	public DbSet<Dissertation> Dissertations { get; set; }
	public DbSet<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
	public DbSet<PublicActivity> PublicActivities { get; set; }
	public DbSet<Department> Departments { get; set; }
	public DbSet<Faculty> Faculties { get; set; }
	public DbSet<Teacher> Teachers { get; set; }
	public DbSet<Student> Students { get; set; }
	public ApplicationContext() : base()
	{
	}
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}