using AspApi.Context;
using AspApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
namespace AspApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public PostController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<Post> Getall()
        {
            var posts = _dbContext.Posts.ToList();
            return posts;
        }

        [HttpPost]
        public Post AddPost(Post post)
        {
            post.CreateDate = DateTime.Now;
            _dbContext.Posts.Add(post);

            bool isSaved = _dbContext.SaveChanges() > 0;

            if(isSaved)
            {
                return post;
            }
            return null;
        }

        [HttpGet]
        public IActionResult GetOnePost(int id) {
            var post = _dbContext.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);

        }

    }
}
