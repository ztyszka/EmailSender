namespace EmailSender.Server.Models;

public class ContactGroupDTO
{
    public int ContactId { get; set; }
    public int GroupId { get; set; }

    public ContactGroupDTO(int groupId, int contactId)
    {
        ContactId = contactId;
        GroupId = groupId;
    }

    public ContactGroupDTO() // required by dapper
    {
    }
}
