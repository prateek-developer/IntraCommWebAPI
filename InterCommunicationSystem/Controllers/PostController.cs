using InterCommunicationSystem.Repository;
using InterCommunicationSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository PostRepository)
        {
            _postRepository = PostRepository;
        }


        [HttpGet("Users")]

        public async Task<IActionResult> GetAllpost(int id)
        {
            var post = await _postRepository.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }


        [HttpPost("Addpost")]

        public async Task<IActionResult> AddNewPost([FromBody] PostViewModel post)
        {

            var posts = await _postRepository.AddNewPost(post);
                return Ok(post);
        }



        [HttpDelete("post/{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _postRepository.DeletePostASync(id);
            return Ok();
        }


    }
}
