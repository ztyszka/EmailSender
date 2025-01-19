using EmailSender.Server.Models;
using EmailSender.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController: ControllerBase
{
    private DbContext _contactRepository;
    public ContactsController(DbContext contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<ContactDTO>> GetContacts()
    {
        return await _contactRepository.GetContacts();
    }

    [HttpPost]
    [Route("new")]
    public async Task AddContact([FromBody] Contact contact)
    {
        await _contactRepository.AddContact(contact);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<List<GroupDTO>> GetGroupsForContact([FromRoute] int id) 
    {
        return await _contactRepository.GetGroupsForContact(id);
    }

    [HttpDelete]
    [Route("{id}/delete")]
    public async Task DeleteContact([FromRoute] int id)
    {
        await _contactRepository.DeleteContact(id);
    }

    [HttpPut]
    [Route("{id}/update")]
    public async Task UpdateContact([FromRoute] int id, [FromBody] Contact contact) 
    {
        // przyjęłam założenie, że można edytować tylko nazwę i adres email kontaktu
        // można również rozważyć edycję przynależności do grup kontaktów

        await _contactRepository.UpdateContact(new ContactDTO(id, contact));
    }
}
