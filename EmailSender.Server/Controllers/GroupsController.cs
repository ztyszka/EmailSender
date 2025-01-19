using EmailSender.Server.Models;
using EmailSender.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly DbContext dbContext;
        public GroupsController(DbContext contactRepository)
        {
            dbContext = contactRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<GroupDTO>> GetGroups()
        {
            return await dbContext.GetGroups();
        }

        [HttpPost]
        [Route("new")]
        public async Task AddGroup([FromBody] string name)
        {
            await dbContext.AddGroup(name);
        }

        [HttpPost]
        [Route("{groupId}/addContact-{contactId}")]
        public async Task AddContactToGroup([FromRoute] int groupId, [FromRoute] int contactId)
        {
            await dbContext.AddContactToGroup(new ContactGroupDTO(groupId, contactId));
        }
    }
}
