using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Models;

namespace Portfolio.Infrastructure.Configurations
{
    class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(post => post.Id);
            builder.HasOne(post => post.User).WithMany(user => user.Posts).HasForeignKey(post => post.UserId);
            builder.HasOne(post => post.Department).WithMany(department => department.Posts).HasForeignKey(post => post.DepartmentId);
        }
    }
}
