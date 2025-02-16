using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Configurations
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public static Department[] departmentData;
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(department => department.Teachers).WithOne(teacher => teacher.Department).HasForeignKey(teacher => teacher.DepartmentId);
            builder.HasData(departmentData);
        }
    }
}
