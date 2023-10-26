using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Helpers;
using PortfolioShared.Models;
using PortfolioShared.Models.Service;

public class ApplicationContext : IdentityDbContext<User, Role, Guid>
{
	public DbSet<Work> Works { get; set; }
	public DbSet<University> Universities { get; set; }
	public DbSet<ScienceProject> ScienceProjects { get; set; }
	public DbSet<Discipline> Disciplines { get; set; }
	public DbSet<Award> Awards { get; set; }
	public DbSet<Publication> Publications { get; set; }
	public DbSet<Dissertation> Dissertations { get; set; }
	public DbSet<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
	public DbSet<Teacher> Teachers { get; set; }
	public DbSet<Student> Students { get; set; }
	public ApplicationContext() : base()
	{
		Database.EnsureCreated();
    }
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
		Database.EnsureCreated();
    }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Teacher>().HasOne(teacher => teacher.User).WithOne(user => user.Teacher).HasPrincipalKey<User>(user => user.Id);
        modelBuilder.Entity<Student>().HasOne(student => student.User).WithOne(user => user.Student).HasPrincipalKey<User>(user => user.Id);

        modelBuilder.Entity<Work>().HasMany(work => work.Teachers).WithMany(teacher => teacher.Works).UsingEntity<WorkTeacher>();
		modelBuilder.Entity<University>().HasMany(university => university.Teachers).WithMany(teacher => teacher.Universities).UsingEntity<UniversityTeacher>();
		modelBuilder.Entity<Discipline>().HasMany(discipline => discipline.Teachers).WithMany(teacher => teacher.Disciplines).UsingEntity<DisciplineTeacher>();
		modelBuilder.Entity<ScienceProject>().HasMany(scienceProject => scienceProject.Teachers).WithMany(teacher => teacher.ScienceProjects).UsingEntity<ScienceProjectTeacher>();

		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Publications).WithOne(publication => publication.Teacher).HasForeignKey(publication => publication.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Awards).WithOne(award => award.Teacher).HasForeignKey(award => award.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Dissertations).WithOne(dissertation => dissertation.Teacher).HasForeignKey(dissertation => dissertation.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.ProfessionalDevelopments).WithOne(professionalDevelopment => professionalDevelopment.Teacher).HasForeignKey(professionalDevelopment => professionalDevelopment.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.AwardStudents).WithOne(awardStudent => awardStudent.Teacher).HasForeignKey(awardStudent => awardStudent.TeacherId);
		modelBuilder.Entity<Student>().HasMany(student => student.AwardStudents).WithOne(awardStudent => awardStudent.Student).HasForeignKey(awardStudent => awardStudent.StudentId);
	}
}