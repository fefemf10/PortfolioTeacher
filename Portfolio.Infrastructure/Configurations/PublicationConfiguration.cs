using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Configurations
{
    class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.HasKey(publication => publication.Id);
            builder.HasMany(publication => publication.CoAuthors).WithMany(teacher => teacher.Publications);
            builder.UseTptMappingStrategy();
        }
    }
}
