using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly InterCommContext context;

        public UserRepository(InterCommContext context)
        {
            this.context = context;
        }


        public async Task<List<UsrProfileViewModel>> GetAllUserAsync()
        {


            return await (from u in context.UserProfiles


                          select new UsrProfileViewModel
                          {
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              Email = u.Email,
                              Contact = u.Contact,
                              Dob = u.Dob,
                              AddressLine1 = u.AddressLine1,
                              AddressLine2 = u.AddressLine2,
                              City = u.City,
                              State = u.State,
                             
                              PermanentCity = u.PermanentCity,
                              PermanentState = u.PermanentState,

                          }).ToListAsync();



        }


        public async Task<UsrProfileViewModel> GetUserNameAsync(string Name)
        {


            var records = await context.UserProfiles.Where(u => u.FirstName == Name).Select(u => new UsrProfileViewModel()
            {


                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Contact = u.Contact,
                Dob = u.Dob,
                AddressLine1 = u.AddressLine1,
                AddressLine2 = u.AddressLine2,
                City = u.City,
                State = u.State,
               
                PermanentCity = u.PermanentCity,
                PermanentState = u.PermanentState,

            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<UserProfile> AddUSerAsync(UsrProfileViewModel user)
        {
            var users = new UserProfile()
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Contact = user.Contact,
                Dob = (System.DateTime)user.Dob,

                Password = PasswordHasher.HashPassword(user.Password),
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                State = user.State,
                
                PermanentCity = user.PermanentCity,
                PermanentState = user.PermanentState,


            };

           
            this.context.UserProfiles.Add(users);

            await context.SaveChangesAsync();







            return users;


        }

        public async Task<bool> checkUserEmail(string email)
        {
            return await context.UserProfiles.AnyAsync(x => x.Email == email);
        }



       



        public async Task DeleteUserAsync(string email)
        {
            var users = context.UserProfiles.Where(x => x.Email == email).FirstOrDefault();
            context.UserProfiles.Remove(users);
           
            await context.SaveChangesAsync();

        }



        public async Task UpdateUserPatch( JsonPatchDocument UserProfile , string FirstName)
        {
            var record = await context.UserProfiles.Where(u => u.FirstName == FirstName).FirstOrDefaultAsync();
            if (record != null)
            {
                UserProfile.ApplyTo(record);
                await context.SaveChangesAsync();
            }
        }



    }
}
