using blog_crud1.Data;
using blog_crud1.Models;
using blog_crud1.Manager;
using Microsoft.AspNetCore.Mvc;


namespace blog_crud1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly BlogDbContext _context;
        CommentManager commentsManager;
        public CommentsController(BlogDbContext context)
        {
            _context = context;
            commentsManager = new CommentManager(_context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comments = await commentsManager.GetAllComments();
            return Ok(comments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comment = await commentsManager.GetCommentById(id);
                return Ok(comment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Comment comment)
        {
            try
            {
                var commentId = await commentsManager.CreateComment(comment);
                return CreatedAtAction(nameof(Get), new { id = commentId }, comment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, Comment updatedComment)
        {
            try
            {
                await commentsManager.UpdateComment(id, updatedComment);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await commentsManager.DeleteComment(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}