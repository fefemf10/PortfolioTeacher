using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;
using System.Text.Json;

namespace Portfolio.Infrastructure.Configurations
{
    class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public static Faculty[] facultiesData;
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasMany(faculty => faculty.Departments).WithOne(department => department.Faculty).HasForeignKey(department => department.FacultyId);
            using FileStream facultyStream = File.OpenRead("SeedData/Faculty.json");
            facultiesData = JsonSerializer.Deserialize<Faculty[]>(facultyStream);
            builder.HasData(facultiesData);
        }
    }
}
