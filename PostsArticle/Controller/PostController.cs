using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostsArticle.Data;
using PostsArticle.DTO;
using PostsArticle.Entities;
using PostsArticle.NewFolder;

namespace PostsArticle.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllpostAsync()
        {
            var post = await _context.Posts.ToListAsync();
            return Ok(post);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PostDto dto)
        {
            var post = new Post {
                PContent = dto.content,
                Title = dto.title,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreaterId = dto.CreaterId,
                UpdatorId=dto.UpdatorId
            };
            await _context.Posts.AddAsync(post);
            _context.SaveChanges();

            return Ok(post);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateAsync(int id, [FromBody] PostDto dto)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);
            if (post == null)
                return BadRequest($"ther is no post with thats ID: {id}");
            post.PContent = dto.content;
            post.Title = dto.title;
            post.CreatedDate = DateTime.Now;
            post.UpdatedDate = DateTime.Now;
            post.CreaterId = dto.CreaterId;
            post.UpdatorId = dto.UpdatorId;

            _context.SaveChanges();
            return Ok(post);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAsync(int id)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);
            if (post == null)
                return BadRequest($"the {id} is not exsit");

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return Ok(post);
        }
    }
}
