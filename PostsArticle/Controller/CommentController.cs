using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostsArticle.Data;
using PostsArticle.DTO;
using PostsArticle.Entities;

namespace CommentsArticle.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllcommentAsync()
        {
            var comment = await _context.Comments.ToListAsync();
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(commentDto dto)
        {
            var par=_context.Comments.FirstOrDefault(x=>x.Id==dto.ParentId); //parent comment
            if (dto.ParentId != null && (dto.PostId != par.PostId)) // check on the postId
            {
                return BadRequest("the postId is not the same of parent comment");
            }
            var comment = new Comment
            {
                Id = dto.Id,
                Content = dto.Content,
                ParentId = dto.ParentId,
                PostId = dto.PostId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreaterId = dto.CreaterId,
                UpdatorId = dto.UpdatorId
                
            };
            try
            {
                par.Child = comment;
                comment.Parent = par;
                comment.Child = null;
                await _context.Comments.AddAsync(comment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest("i am in catch weeeeeeweeeeeee....."+ex.Message);
            }
            return Ok(comment);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateAsync(int id, [FromBody] commentDto dto)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(x => x.Id == id);
            if (comment == null)
                return BadRequest($"there is no comment with thats ID: {id}");

            comment.Content = dto.Content;
            comment.ParentId = dto.ParentId;
            comment.PostId = dto.PostId;
            comment.CreatedDate = DateTime.Now;
            comment.UpdatedDate = DateTime.Now;
            comment.CreaterId = dto.CreaterId;
            comment.UpdatorId = dto.UpdatorId;

            _context.SaveChanges();
            return Ok(comment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAsync(int id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(x => x.Id == id);
            if (comment == null)
                return BadRequest($"the {id} is not exsit");

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return Ok(comment);
        }
    }
}
