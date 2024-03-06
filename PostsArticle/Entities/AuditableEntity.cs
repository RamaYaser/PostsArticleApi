namespace PostsArticle.Entities
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public int? CreaterId { get; set; } //FK in comment and post
        public User? CreaterUser { get; set; }
        public int? UpdatorId  {get; set; } //FK can be null or 
        public User? UbdaterUser { get; set; }
    }
}
