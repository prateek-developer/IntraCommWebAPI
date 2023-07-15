using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace InterCommunicationSystem.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly InterCommContext _db;


        public GroupRepository(InterCommContext context)
        {
            _db = context;
        }



        public async Task<List<Group>> GetAllGroupsAsync()
        {


            return await (from u in _db.Groups


                          select new Group
                          {
                              GroupName = u.GroupName,
                              GroupDescription = u.GroupDescription,
                              CreatedBy = u.CreatedBy,
                              CreatedAt = u.CreatedAt

                          }).ToListAsync();



        }

       public async Task<Group> AddGroupAsync(GroupViewModel group , int id)
        {
                var Group = new Group()
                {
                    GroupName = group.GroupName,
                    GroupType = group.GroupType,
                    GroupDescription = group.GroupDescription,
                    CreatedAt = group.CreatedAt,
                    CreatedBy = id,
                    


                };
            try
            {



                await _db.Groups.AddAsync(Group);

                await _db.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


           







            return Group;



        }


        public async Task<bool> checkGroupName(string name)
        {
            return await _db.Groups.AnyAsync(x => x.GroupName == name);
        }


        public async Task DeleteGroupAsync(string GroupName)
        {
            var group = _db.Groups.Where(x => x.
            GroupName== GroupName).FirstOrDefault();
            _db.Groups.Remove(group);

            await _db.SaveChangesAsync();

        }

        public async Task UpdateGroupPatch(JsonPatchDocument Group, int groupId)
        {
            var record = await _db.Groups.Where(u => u.CreatedBy == groupId).FirstOrDefaultAsync();
            if (record != null)
            {
                Group.ApplyTo(record);
                await _db.SaveChangesAsync();
            }
        }


        public async Task<Boolean> SendInvite_Request(GroupRequestViewModel invite)
        {
            if (invite == null) return false;
            var new_invite = new GroupInvitesRequest()
            {
                SentTo = invite.SentTo,
                GroupId = invite.GroupId,
                IsAccepted = invite.IsAccepted,
                IsApproved = invite.IsApproved,
                CreatedBy = invite.CreatedBy,
                CreatedAt = invite.CreatedAt,
                UpdatedAt = invite.UpdatedAt,
            };
            await _db.GroupInvitesRequests.AddAsync(new_invite);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> AddGroupMember(GroupMember member)
        {
            var new_member = new GroupMember()
            {
                GroupId = member.GroupId,
                MemberId = member.MemberId,
            };
            // Check if a user has already sent request to join the group
            var isRequested = await _db.GroupInvitesRequests.Where(gID => (gID.GroupId == member.GroupId) && (gID.CreatedBy == member.MemberId)).FirstOrDefaultAsync();

            // the user has not sent request then invite the user
            if (isRequested == null)
            {
                var group = await _db.Groups.Where(g => g.GroupId == member.GroupId).FirstOrDefaultAsync();

                var invite = new GroupRequestViewModel()
                {
                    SentTo = member.MemberId,
                    GroupId = member.GroupId,
                    IsAccepted = false,
                    IsApproved = true,
                    CreatedBy = group.CreatedBy,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
                };
                return await SendInvite_Request(invite);

            }
            else
            {
                // if the user has sent the request to join then approve his request.
                isRequested.IsApproved = true;
                await _db.GroupMembers.AddAsync(member);
                return true;
            }
        }

        public async Task<Boolean> AcceptInvite(int inviteID)
        {
            var invite = await _db.GroupInvitesRequests.FindAsync(inviteID);

            if (invite != null)
            {
                invite.IsAccepted = true;
                var member = new GroupMember()
                {
                    MemberId = invite.SentTo,
                    GroupId = invite.GroupId,
                };
                await _db.GroupMembers.AddAsync(member);
                _db.GroupInvitesRequests.Remove(invite);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }

}


