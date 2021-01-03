using ArifOmer.BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArifOmer.BlogApp.DataAccess.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.UserName).IsRequired();
            builder.Property(I => I.UserName).HasMaxLength(150);

            builder.Property(I => I.Email).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(100);

            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.Name).HasMaxLength(100);

            builder.Property(I => I.SurName).IsRequired();
            builder.Property(I => I.SurName).HasMaxLength(100);

            builder
                .HasMany(I => I.Blogs)
                .WithOne(I => I.AppUser)
                .HasForeignKey(I => I.AppUserId);
        }
    }
}
