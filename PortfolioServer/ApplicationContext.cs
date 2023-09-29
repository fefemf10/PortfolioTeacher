using Microsoft.EntityFrameworkCore;
using PortfolioServer.Models;
using System.Security.Principal;

public class ApplicationContext : DbContext
{
    public DbSet<Work> Works { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Award> Awards { get; set; }
    public DbSet<ProfessionalDevelopment> ProfessionalDevelopments { get; set; }
    public DbSet<Dissertation> Dissertations { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Publication> Publications { get; set; }
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
        modelBuilder.Entity<Work>().HasKey(work => work.Id);
        modelBuilder.Entity<Teacher>().HasKey(teacher => teacher.Id);
        modelBuilder.Entity<University>().HasKey(university => university.Id);
        modelBuilder.Entity<Award>().HasKey(award => award.Id);
        modelBuilder.Entity<ProfessionalDevelopment>().HasKey(professionalDevelopment => professionalDevelopment.Id);
        //modelBuilder.Entity<Account>().HasIndex(acc => acc.Email).IsUnique();

        //modelBuilder.Entity<LocationPoint>().HasKey(p => p.Id);

        //modelBuilder.Entity<AnimalType>().HasKey(t => t.Id);

        //modelBuilder.Entity<Area>().HasKey(t => t.Id);
        //modelBuilder.Entity<LocationPoint>().HasMany(v => v.Areas).WithMany(a => a.AreaPoints);
        //modelBuilder.Entity<AnimalVisitedLocation>().HasKey(v => v.Id);

        //modelBuilder.Entity<Animal>().HasKey(a => a.Id);
        //modelBuilder.Entity<Animal>().HasOne(v => v.ChippingLocation).WithMany(a => a.Animals).HasForeignKey(v => v.ChippingLocationId);
        //modelBuilder.Entity<Animal>().HasOne(v => v.Chipper).WithMany(a => a.Animals).HasForeignKey(v => v.ChipperId);
        //modelBuilder.Entity<Animal>().HasMany(v => v.VisitedLocations).WithMany(a => a.Animals).UsingEntity<AnimalAnimalVisitedLocation>(
        //    j => j
        //    .HasOne(pt => pt.VisitedLocation)
        //    .WithMany(t => t.AnimalVisitedLocations)
        //    .HasForeignKey(pt => pt.AnimalId),
        //    j => j
        //    .HasOne(pt => pt.Animal)
        //    .WithMany(p => p.AnimalVisitedLocations)
        //    .HasForeignKey(pt => pt.VisitedLocationId),
        //    j =>
        //    {
        //        j.HasKey(c => c.Id);
        //    });
    }
}