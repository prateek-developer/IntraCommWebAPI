using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public class LoginRepository : ILoginRepository
    {

        private readonly InterCommContext _db;


        public LoginRepository(InterCommContext context)
        {
            _db = context;
        }







        public async Task<UserProfiles> Login(UserProfile User)
        {
            var user_obj = await _db.UserProfiles.Where(x => x.Email == User.Email).Select(x => new UserProfiles()
            {
                Email= x.Email,
                Password = x.Password,
               
            })
                .FirstOrDefaultAsync();


            return user_obj;

        }


    



    }


    }
