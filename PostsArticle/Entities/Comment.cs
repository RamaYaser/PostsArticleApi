using System.Text.Json.Serialization;

namespace PostsArticle.Entities
{
    public class Comment :AuditableEntity
    {
        public string Content {  get; set; }
        public int? ParentId { get; set; }
        [JsonIgnore]
        public Comment? Parent { get; set; }
        [JsonIgnore]
        public Comment? Child { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
