using ArifOmer.BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArifOmer.BlogApp.DataAccess.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).IsRequired();
            builder.Property(I => I.Title).HasMaxLength(250);

            builder.Property(I => I.ShortDescription).IsRequired();
            builder.Property(I => I.ShortDescription).HasMaxLength(400);

            builder.Property(I => I.Description).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder
                .HasMany(I => I.CategoryBlogs)
                .WithOne(I => I.Blog)
                .HasForeignKey(I => I.BlogId);

            builder
                .HasMany(I => I.Comments)
                .WithOne(I => I.Blog)
                .HasForeignKey(I => I.BlogId);
        }
    }
}
