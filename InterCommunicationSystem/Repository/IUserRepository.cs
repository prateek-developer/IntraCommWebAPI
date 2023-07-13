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

        Task<List<UsrProfileViewModel>> GetAllUserAsync();
        Task<UsrProfileViewModel> GetUserNameAsync(string Name);


        Task<UserProfile> AddUSerAsync(UsrProfileViewModel user);

         Task DeleteUserAsync(string email);

        Task UpdateUserPatch(JsonPatchDocument UserProfile, string FirstName);
 
            Task<bool> checkUserEmail(string email);
        

    }
}
