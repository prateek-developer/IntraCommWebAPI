using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public class JWTWebAuthentication : IJWTWebAuthentication


    {

		
		private readonly InterCommContext context;
		


        public JWTWebAuthentication(InterCommContext context, IConfiguration configuration)
        {
            this.context = context;
			Configuration = configuration;
        }
		public IConfiguration Configuration { get; }


		public TokenViewModel authenticate(LoginViewModel Login)
        {
			if (!context.UserProfiles.Any(x => x.Email == Login.Email && x.Password == Login.Password))
			{
				return null;
			}

			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Email, Login.Email)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new TokenViewModel { Token = tokenHandler.WriteToken(token) };
		}




    }
}
