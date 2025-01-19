namespace EmailSender.Server.Repositories;

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using EmailSender.Server.Models;
using EmailSender.Server.Options;
using Microsoft.Extensions.Options;

public class DbContext
{
    private readonly SQLiteConnection _sqLiteConnection;

    public DbContext(IOptions<DatabaseOptions> options)
    {
        string connectionString = options.Value.ConnectionSting;
        _sqLiteConnection = new SQLiteConnection(connectionString);
    }

    public async Task<List<ContactDTO>> GetContacts()
    {
        _sqLiteConnection.Open();
        var query = "SELECT * FROM Contacts";
        var selected = await _sqLiteConnection.QueryAsync<ContactDTO>(query);

        _sqLiteConnection.Close();
        return selected.ToList();
    }

    public async Task AddContact(Contact contact)
    {
        _sqLiteConnection.Open();
        var query = $"INSERT INTO Contacts (Name, Email) VALUES ('{contact.Name}', '{contact.Email}')";
        await _sqLiteConnection.ExecuteAsync(query);
        _sqLiteConnection.Close();
    }

    public async Task DeleteContact(int id)
    {
        _sqLiteConnection.Open();
        var query = @$"BEGIN TRANSACTION;
            DELETE FROM ContactsGroups WHERE ContactId = {id};
            DELETE FROM Contacts WHERE id = {id};
            COMMIT;";
        await _sqLiteConnection.ExecuteAsync(query);
        _sqLiteConnection.Close();
    }

    public async Task UpdateContact(ContactDTO contact)
    {
        _sqLiteConnection.Open();
        var query = @$"UPDATE Contacts SET Name = '{contact.Name}', Email = '{contact.Email}'
            WHERE id = {contact.Id}";
        await _sqLiteConnection.ExecuteAsync(query);
        _sqLiteConnection.Close();
    }

    public async Task<List<GroupDTO>> GetGroupsForContact(int contactId)
    {
        _sqLiteConnection.Open();
        var query = @$"SELECT g.Id, g.Name FROM Groups g
            JOIN ContactsGroups cg ON g.Id = cg.groupId
            WHERE cg.contactId = {contactId}";
            
        var selected = await _sqLiteConnection.QueryAsync<GroupDTO>(query);

        _sqLiteConnection.Close();
        return selected.ToList();
    }

    public async Task<List<ContactDTO>> GetContactsForGroup(int groupId)
    {
        _sqLiteConnection.Open();
        var query = @$"SELECT c.Id, c.Name, c.Email FROM Contacts c
            JOIN ContactsGroups cg ON c.Id = cg.contactId
            WHERE cg.groupId = {groupId}";

        var selected = await _sqLiteConnection.QueryAsync<ContactDTO>(query);

        _sqLiteConnection.Close();
        return selected.ToList();
    }

    public async Task<List<GroupDTO>> GetGroups()
    {
        _sqLiteConnection.Open();
        var query = "SELECT * FROM Groups";
        var selected = await _sqLiteConnection.QueryAsync<GroupDTO>(query);

        _sqLiteConnection.Close();
        return selected.ToList();
    }

    public async Task<int> AddGroup(string name)
    {
        // można dodać weryfikację czy grupa o takiej nazwie już istnieje,
        // jeśli zależy nam na unikalności nazwy
        _sqLiteConnection.Open();
        var query = $"INSERT INTO Groups (Name) VALUES ('{name}')";
        var result = await _sqLiteConnection.ExecuteAsync(query);
        _sqLiteConnection.Close();
        return result;
    }

    public async Task AddContactToGroup(ContactGroupDTO contactGroup)
    {
        _sqLiteConnection.Open();
        var query = @$"INSERT INTO ContactsGroups (ContactId, GroupId) 
            VALUES ('{contactGroup.ContactId}', '{contactGroup.GroupId}')";
        await _sqLiteConnection.ExecuteAsync(query);
        _sqLiteConnection.Close();
    }

    public async Task<List<Contact>> GetEmailsFromGroup(int groupId)
    {
        _sqLiteConnection.Open();
        var query = $@"SELECT Name, Email FROM Contacts c JOIN ContactsGroups cg 
            ON c.Id = cg.ContactId
            WHERE cg.GroupId = {groupId}";
        var result = await _sqLiteConnection.QueryAsync<Contact>(query);
        _sqLiteConnection.Close();
        return result.ToList();
    }
}
