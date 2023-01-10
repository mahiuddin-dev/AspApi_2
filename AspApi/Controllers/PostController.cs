using AspApi.Context;
using AspApi.Interfaces.Manager;
using AspApi.Managers;
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
        //private readonly ApplicationDBContext _dbContext;
        //PostManager _postManager;

        //public PostController(ApplicationDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _postManager = new PostManager(dbContext);
        //}

        iPostManager _postManager;
        public PostController(iPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet]
        public List<Post> Getall()
        {
           // var posts = _dbContext.Posts.ToList();
           var posts = _postManager.GetAll().ToList();
           return posts;
        }

        [HttpPost]
        public Post AddPost(Post post)
        {
            post.CreateDate = DateTime.Now;

            // _dbContext.Posts.Add(post);
            // bool isSaved = _dbContext.SaveChanges() > 0;

            bool isSaved = _postManager.Add(post);

            if(isSaved)
            {
                return post;
            }
            return null;
        }

        [HttpGet("{id}")]
        public IActionResult GetOnePost(int id) {
            //var post = _dbContext.Posts.Find(id);
            var post = _postManager.GetById(id);
            if (post == null )
            {
                return NotFound();
            }
            return Ok(post);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Post post)
        {
            var existingPost = _postManager.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }
            bool isSaved = _postManager.Update(post);
            if (isSaved)
            {
                return Ok(post);
            }
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _postManager.GetById(id);
            if(post != null)
            {
                bool isDelete = _postManager.Delete(post);
                if(isDelete)
                {
                    return Ok(post);
                }
                return BadRequest();
            }
            return NotFound();
        }


    }
}
