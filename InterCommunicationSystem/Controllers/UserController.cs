using InterCommunicationSystem.Repository;
using InterCommunicationSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }


        [HttpGet("Users")]

        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userRepository.GetAllUserAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }


        [HttpGet("Users/{Name}")]

        public async Task<IActionResult> GetuserByName([FromRoute] string Name)
        {
            var users = await _userRepository.GetUserNameAsync(Name);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }


        [ActionName("GetAsync")]
        [HttpPost("SignUP")]


        public async Task<IActionResult> AddUser([FromBody] UsrProfileViewModel User)
        {

            if (await _userRepository.checkUserEmail(User.Email))
                return BadRequest(new
                {
                    Message = "username already exist"
                });

            var id = await _userRepository.AddUSerAsync(User);
            return Ok(User);
        }




       
        [HttpDelete("user/{email}")]

        public async Task<IActionResult> DeleteUser([FromRoute] string email)
        {
            await _userRepository.DeleteUserAsync($"{email}");
            return Ok();
        }



        [HttpPatch("patch/{FirstName}")]

        public async Task<IActionResult> UpdateUserPatch([FromBody] JsonPatchDocument UserProfile, [FromRoute] string FirstName)
        {
            await _userRepository.UpdateUserPatch(UserProfile, FirstName);
            return Ok();
        }



    }

}
