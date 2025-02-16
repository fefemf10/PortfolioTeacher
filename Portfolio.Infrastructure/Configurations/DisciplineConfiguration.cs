using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Configurations
{
    class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public static Discipline[] disciplinesData;
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasMany(discipline => discipline.Teachers).WithMany(teacher => teacher.Disciplines);
            builder.HasData(disciplinesData);
        }
    }
}
