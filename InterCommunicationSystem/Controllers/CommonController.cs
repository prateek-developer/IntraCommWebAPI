using InterCommunicationSystem.Models;
using InterCommunicationSystem.Repository;
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
    public class CommonController : ControllerBase
    {


        private readonly ICommonRepository _commonRepository;

        public CommonController(ICommonRepository commmonRepository)
        {
            _commonRepository = commmonRepository;
        }



        [HttpPost("Like")]


        public async Task<IActionResult> AddLike([FromRoute] int userid, [FromRoute] int Postid)
        {

           

            await _commonRepository.AddLikeAsync(userid, Postid);
            return Ok();
        }

        [HttpPost("comment")]


        public async Task<IActionResult> AddComment([FromBody] Comment new_comment)
        {



          await _commonRepository.AddUCommentAsync( new_comment);
            return Ok(new_comment);
        }

        [HttpDelete("comment/{id}")]

        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            await _commonRepository.DeleteCommentAsync(id);
            return Ok();
        }

        [HttpGet("Comment/{PostId}")]

        public async Task<IActionResult> GetuserByName([FromRoute] int PostId)
        {
            var comments = await _commonRepository.getAllPostComment(PostId);
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }
    }
}
