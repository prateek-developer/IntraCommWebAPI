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
    }

}


