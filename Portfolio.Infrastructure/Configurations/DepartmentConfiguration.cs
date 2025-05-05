using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Portfolio.Infrastructure.Configurations
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public static Department[] departmentData;
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(department => department.ChildDepartments).WithOne(department => department.ParentDepartment).HasForeignKey(department => department.ParentDepartmentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(department => department.Posts).WithOne(post => post.Department).HasForeignKey(post => post.DepartmentId);

            using FileStream departmentStream = File.OpenRead("SeedData/Department.json");
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            departmentData = JsonSerializer.Deserialize<Department[]>(departmentStream, options);
            builder.HasData(departmentData);
        }
    }
}
