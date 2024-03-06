using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PostsArticle.Entities;

namespace PostsArticle.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            ////modelBuilder.Entity<User>()
            ////    .Property(x => x.Id)
            ////    .ValueGeneratedOnAdd();
            ////modelBuilder.Entity<Comment>()
            ////    .Property(x => x.Id)
            ////    .ValueGeneratedOnAdd();
            ////modelBuilder.Entity<Post>()
            ////    .Property(x => x.Id)
            ////    .ValueGeneratedOnAdd();

        }

    }
}
