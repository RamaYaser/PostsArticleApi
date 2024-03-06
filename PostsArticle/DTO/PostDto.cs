using PostsArticle.Entities;

namespace PostsArticle.DTO
{
    public class PostDto
    {
        public string content { get; set; }
        public string title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime?UpdatedDate { get; set; } = DateTime.Now;
        public int? CreaterId { get; set; } //FK in comment and post
        public int? UpdatorId { get; set; } //FK can be null 
    }
}
