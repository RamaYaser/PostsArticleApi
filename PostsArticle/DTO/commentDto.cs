using PostsArticle.Entities;

namespace PostsArticle.DTO
{
    public class commentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public int? CreaterId { get; set; } //FK in comment and post
        public int? UpdatorId { get; set; } //FK can be null or 
    }
}
