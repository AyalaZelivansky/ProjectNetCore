using DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Serilog;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerPost : ControllerBase
    {
        private readonly IPost _Post;
        public ControllerPost(IPost post)
        {
            _Post = post;
        }

        [HttpGet]
        [Route("/PostGet")]

        public async Task<ActionResult<List<Post>>> Get()
        {
            List<Post> res = await _Post.GetAllPost();
            Log.Information("getPost");

            return Ok(res);
        }


        [HttpPost]
        [Route("/PostPost")]
        public async Task<ActionResult> PostPost([FromBody] Post p)
        {
            await _Post.AddPost(p);
            Log.Information("postt");

            return Ok();
        }

        [HttpPut]
        [Route("/PostPut{id}")]

        public async Task<ActionResult> PutPost(int id, [FromBody] Post post)
        {
            await _Post.UpdatePost(id, post);
            Log.Information("PutPost");

            return Ok();
        }

        [HttpPut]
        [Route("/PostLikePut{id}")]

        public async Task<ActionResult> PutPostLike(int id, bool like)
        {
            await _Post.UpdatePostiLike(id, like);
            Log.Information("PutPostLike");

            return Ok();
        }


        [HttpDelete]
        [Route("/PostDelete{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _Post.DeletePost(id);
            return Ok();
        }
    }
}
