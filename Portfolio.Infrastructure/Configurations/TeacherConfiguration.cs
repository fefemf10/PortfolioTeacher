using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Configurations
{
    class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasMany(teacher => teacher.Universities).WithOne(university => university.Teacher).HasForeignKey(university => university.TeacherId);
            builder.HasMany(teacher => teacher.Works).WithOne(work => work.Teacher).HasForeignKey(work => work.TeacherId);
            builder.HasMany(teacher => teacher.ScienceProjects).WithOne(scienceProject => scienceProject.Teacher).HasForeignKey(scienceProject => scienceProject.TeacherId);
            builder.HasMany(teacher => teacher.Publications).WithOne(publication => publication.Teacher).HasForeignKey(publication => publication.TeacherId);
            builder.HasMany(teacher => teacher.Awards).WithOne(award => award.Teacher).HasForeignKey(award => award.TeacherId);
            builder.HasMany(teacher => teacher.Dissertations).WithOne(dissertation => dissertation.Teacher).HasForeignKey(dissertation => dissertation.TeacherId);
            builder.HasMany(teacher => teacher.ProfessionalDevelopments).WithOne(professionalDevelopment => professionalDevelopment.Teacher).HasForeignKey(professionalDevelopment => professionalDevelopment.TeacherId);
            builder.HasMany(teacher => teacher.PublicActivities).WithOne(publicActivity => publicActivity.Teacher).HasForeignKey(publicActivity => publicActivity.TeacherId);
            builder.HasMany(teacher => teacher.AwardStudents).WithOne(awardStudent => awardStudent.Teacher).HasForeignKey(awardStudent => awardStudent.TeacherId);
        }
    }
}
