using ArifOmer.BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArifOmer.BlogApp.DataAccess.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.Name).HasMaxLength(250);

            builder
                .HasMany(I => I.CategoryBlogs)
                .WithOne(I => I.Category)
                .HasForeignKey(I => I.CategoryId);
        }
    }
}
