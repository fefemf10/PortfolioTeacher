using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;
using System.Text.Json;

namespace Portfolio.Infrastructure.Configurations
{
    class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public static Discipline[] disciplinesData;
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasMany(discipline => discipline.Teachers).WithMany(teacher => teacher.Disciplines);
            using FileStream disciplineStream = File.OpenRead("SeedData/Discipline.json");
            disciplinesData = JsonSerializer.Deserialize<Discipline[]>(disciplineStream);
            builder.HasData(disciplinesData);
        }
    }
}
