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
    public class GroupController : ControllerBase
    {

        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }


        [HttpGet("Groups")]

        public async Task<IActionResult> GetAllGroups()
        {
            var Groups = await _groupRepository.GetAllGroupsAsync();
            if (Groups == null)
            {
                return NotFound();
            }
            return Ok(Groups);
        }


        [HttpPost("AddGroups/{createdBy}")]


        public async Task<IActionResult> AddGroup([FromBody] GroupViewModel group , [FromRoute] int createdBy)
        {

            if (await _groupRepository.checkGroupName(group.GroupName))
                return BadRequest(new
                {
                    Message = "GroupName already exist"
                });

            await _groupRepository.AddGroupAsync(group  , createdBy);
            return Ok(group);
        }



        [HttpDelete("group/{GroupName}")]

        public async Task<IActionResult> DeleteUser([FromRoute] string GroupName)
        {
            await _groupRepository.DeleteGroupAsync($"{GroupName}");
            return Ok();
        }



        [HttpPatch("patch/{GroupId}")]

        public async Task<IActionResult> UpdateUserPatch([FromBody] JsonPatchDocument Group, [FromRoute] int groupId)
        {
            await _groupRepository.UpdateGroupPatch(Group, groupId);
            return Ok();
        }

    }
}
