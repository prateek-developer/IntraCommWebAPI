using InterCommunicationSystem.Models;
using InterCommunicationSystem.Repository;
using InterCommunicationSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
/*
        private readonly ILoginRepository _loginRepository;
*/
        private readonly IJWTWebAuthentication _jWTWebAuthentication;
/*
        public LoginController(ILoginRepository LoginRepository)
        {
            _loginRepository = LoginRepository;
        }
*/
        public LoginController(IJWTWebAuthentication jWTWebAuthentication)
        {
            this._jWTWebAuthentication = jWTWebAuthentication;
        }

/*
        [AllowAnonymous]
        [HttpPost("authentication")]

        public async Task<IActionResult> LoginUSer([FromBody] UserProfile user0bj)
        {

*/


            /* if (user0bj == null)
             {
                 return BadRequest();
             }


             var user = await _loginRepository.Login(user0bj);
             if (user == null)
             {
                 return NotFound("not found");
             }
             if (!PasswordHasher.VerifyPassword(user0bj.Password, user.Password))
             {
                 return BadRequest(new
                 {
                     message = "Password is incorrect"
                 });
             }
             var token = _jWTWebAuthentication.authenticate(user0bj);

             if (token == null)
             {
                 return Unauthorized();
             }
             return Ok(token) ;
         }*/

            [HttpPost]
            [Route("authenticate")]
        public async Task<IActionResult> authenticate([FromBody] LoginViewModel user0bj)
        {
                var token = _jWTWebAuthentication.authenticate(user0bj);

                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(token);
            }


        }






    }
