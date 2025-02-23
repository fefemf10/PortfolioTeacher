using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;
using System.Text.Json;

namespace Portfolio.Infrastructure.Configurations
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public static Department[] departmentData;
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(department => department.Teachers).WithOne(teacher => teacher.Department).HasForeignKey(teacher => teacher.DepartmentId);
            using FileStream departmentStream = File.OpenRead("SeedData/Department.json");
            departmentData = JsonSerializer.Deserialize<Department[]>(departmentStream);
            builder.HasData(departmentData);
        }
    }
}
