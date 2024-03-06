using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostsArticle.Data;
using PostsArticle.Entities;
using PostsArticle.NewFolder;

namespace PostsArticle.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllUserAsync()
        {
            var user = await _context.Users.ToListAsync();
            return Ok(user);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserDto dto)
        {
            var user = new User { 
                Fname = dto.Fname,
                Lname = dto.Lname 
            };
            await _context.Users.AddAsync(user);
            _context.SaveChanges();

            return Ok(user);
        }
        [HttpPut ("{id}")] //update data for specific id
        public async Task<IActionResult> updateAsync(int id, [FromBody] UserDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return BadRequest($"their is no user with that ID: {id}");
            user.Fname = dto.Fname;
            user.Lname = dto.Lname;
            _context.SaveChanges();

            return Ok(user);
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> deleteAsync(int id)
        {
            var user= await _context.Users.SingleOrDefaultAsync(x=>x.Id == id);
            if (user == null)
                return BadRequest($"the {id} is not exsit");

            _context.Users.Remove(user);

            _context.SaveChanges();
            return Ok(user);
        }
    }
}
