using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasMany(user => user.Universities).WithOne(university => university.User).HasForeignKey(university => university.UserId);
            builder.HasMany(user => user.Works).WithOne(work => work.User).HasForeignKey(work => work.UserId);
            builder.UseTptMappingStrategy();
        }
    }
}
