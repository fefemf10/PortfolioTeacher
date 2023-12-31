﻿using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

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
	
	public static Discipline[] disciplinesData;
	public static Faculty[] facultiesData;
	public static Department[] departmentData;

	public ApplicationContext() : base()
	{
	}
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<User>().HasKey(user => user.Id);
		modelBuilder.Entity<User>().UseTptMappingStrategy();

		modelBuilder.Entity<Discipline>().HasMany(discipline => discipline.Teachers).WithMany(teacher => teacher.Disciplines);
		modelBuilder.Entity<Department>().HasMany(department => department.Teachers).WithOne(teacher => teacher.Department).HasForeignKey(teacher => teacher.DepartmentId);
		modelBuilder.Entity<Faculty>().HasMany(faculty => faculty.Departments).WithOne(department => department.Faculty).HasForeignKey(department => department.FacultyId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.ScienceProjects).WithOne(scienceProject => scienceProject.Teacher).HasForeignKey(scienceProject => scienceProject.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Universities).WithOne(university => university.Teacher).HasForeignKey(university => university.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Works).WithOne(work => work.Teacher).HasForeignKey(work => work.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Publications).WithOne(publication => publication.Teacher).HasForeignKey(publication => publication.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Awards).WithOne(award => award.Teacher).HasForeignKey(award => award.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Dissertations).WithOne(dissertation => dissertation.Teacher).HasForeignKey(dissertation => dissertation.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.ProfessionalDevelopments).WithOne(professionalDevelopment => professionalDevelopment.Teacher).HasForeignKey(professionalDevelopment => professionalDevelopment.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.PublicActivities).WithOne(publicActivity => publicActivity.Teacher).HasForeignKey(publicActivity => publicActivity.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.AwardStudents).WithOne(awardStudent => awardStudent.Teacher).HasForeignKey(awardStudent => awardStudent.TeacherId);
		modelBuilder.Entity<Student>().HasMany(student => student.AwardStudents).WithOne(awardStudent => awardStudent.Student).HasForeignKey(awardStudent => awardStudent.StudentId);
        modelBuilder.Entity<Discipline>().HasData(disciplinesData);
        modelBuilder.Entity<Faculty>().HasData(facultiesData);
        modelBuilder.Entity<Department>().HasData(departmentData);
    }
}