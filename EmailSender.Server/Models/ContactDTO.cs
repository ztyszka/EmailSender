namespace EmailSender.Server.Models;


public class Contact
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
}

public class ContactDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public ContactDTO(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public ContactDTO(int id, Contact contact)
    {
        Id = id;
        Name = contact.Name;
        Email = contact.Email;
    }

    public ContactDTO() // required by dapper
    {
    }
}
