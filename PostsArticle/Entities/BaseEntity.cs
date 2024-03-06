using System.ComponentModel.DataAnnotations.Schema;

namespace PostsArticle.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //to incremint id automaticly 
        public int Id { get; set; }
    }
}
