namespace PostsArticle.Entities
{
    public class Post : AuditableEntity
    {
        public string Title { get; set; }
        public string PContent { get; set; }
        public List<Comment>? comments { get; set; } = new();
    }
}
