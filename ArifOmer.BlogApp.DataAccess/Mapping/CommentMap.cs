using ArifOmer.BlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArifOmer.BlogApp.DataAccess.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.AuthorName).IsRequired();
            builder.Property(I => I.AuthorName).HasMaxLength(150);

            builder.Property(I => I.AuthorEmail).IsRequired();
            builder.Property(I => I.AuthorEmail).HasMaxLength(100);

            builder.Property(I => I.Description).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(500);

            builder
                .HasMany(I => I.SubComments)
                .WithOne(I => I.ParentComment)
                .HasForeignKey(I => I.ParentCommentId);
        }
    }
}
