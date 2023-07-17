using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public interface IUserRepository
    {

        Task<List<UserProfile>> GetAllUserAsync();
        Task<UserProfile> GetUserNameAsync(string Name);


        Task<UserProfiles> AddUSerAsync(UserProfile user);

         Task DeleteUserAsync(string email);

        Task UpdateUserPatch(JsonPatchDocument UserProfile, string FirstName);
 
            Task<bool> checkUserEmail(string email);

        Task<bool> IsValidEmail(string email);




        }
}
