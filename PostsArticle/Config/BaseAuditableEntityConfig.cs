using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostsArticle.Entities;

namespace PostsArticle.Config
{
    public class BaseAuditableEntityConfig<TEntity>  : BaseEntityConfig<TEntity> where TEntity : AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

        }
    }
}
