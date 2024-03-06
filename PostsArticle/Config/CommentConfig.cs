using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostsArticle.Entities;

namespace PostsArticle.Config
{
    public class CommentConfig : BaseAuditableEntityConfig<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Post)
                .WithMany(x => x.comments)
                .HasForeignKey(x => x.PostId);
                
            builder.ToTable("Comments");
        }
    }
}