﻿using Microsoft.EntityFrameworkCore;
using PortfolioServer.Models;
using System.Reflection.Metadata;
using System.Security.Principal;

public class ApplicationContext : DbContext
{
	public DbSet<Work> Works { get; set; }
	public DbSet<University> Universities { get; set; }
	public DbSet<Discipline> Disciplines { get; set; }
	public DbSet<Award> Awards { get; set; }
	public DbSet<Publication> Publications { get; set; }
	public DbSet<Dissertation> Dissertations { get; set; }
	public DbSet<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
	public DbSet<Teacher> Teachers { get; set; }
	public ApplicationContext() : base()
	{
		if (!Database.EnsureCreated())
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}
        else
            Database.EnsureCreated();
    }
	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
		if (!Database.EnsureCreated())
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}
		else
            Database.EnsureCreated();
    }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.Entity<Work>().HasMany(work => work.Teachers).WithMany(teacher => teacher.Works).UsingEntity<WorkTeacher>();
		modelBuilder.Entity<University>().HasMany(university => university.Teachers).WithMany(teacher => teacher.Universities).UsingEntity<UniversityTeacher>();
		modelBuilder.Entity<Discipline>().HasMany(discipline => discipline.Teachers).WithMany(teacher => teacher.Disciplines).UsingEntity<DisciplineTeacher>();
		//modelBuilder.Entity<ProfessionalDevelopment>().HasMany(professionalDevelopment => professionalDevelopment.Teachers).WithMany(teacher => teacher.ProfessionalDevelopments).UsingEntity<ProfessionalDevelopmentTeacher>();
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Publications).WithOne(publication => publication.Teacher).HasForeignKey(publication => publication.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Awards).WithOne(award => award.Teacher).HasForeignKey(award => award.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.Dissertations).WithOne(dissertation => dissertation.Teacher).HasForeignKey(dissertation => dissertation.TeacherId);
		modelBuilder.Entity<Teacher>().HasMany(teacher => teacher.ProfessionalDevelopments).WithOne(professionalDevelopment => professionalDevelopment.Teacher).HasForeignKey(professionalDevelopment => professionalDevelopment.TeacherId);
	}
}