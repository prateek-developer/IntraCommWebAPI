using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public interface IGroupRepository
    {

        Task<List<Group>> GetAllGroupsAsync();

        Task<Group> AddGroupAsync(GroupViewModel group, int id);
        Task DeleteGroupAsync(string email);

        Task UpdateGroupPatch(JsonPatchDocument Group, int groupId);

        Task<bool> checkGroupName(string GroupName);

        Task<Boolean> SendInvite_Request(GroupRequestViewModel invite);
        Task<Boolean> AddGroupMember(GroupMember member);

        Task<Boolean> AcceptInvite(int inviteID);

    }
}
