using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PostsArticle.Entities;

namespace PostsArticle.Config
{
    public class PostConfig : BaseAuditableEntityConfig<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);
            builder.ToTable("Posts");
        }
    }
}
