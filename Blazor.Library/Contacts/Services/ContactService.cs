using Blazor.Library.Contacts.Interfaces;

namespace Blazor.Library.Contacts.Services;

public class ContactService : IContact
{
    static private List<Contact> ContactList = new()
    {
        new Contact { Id = 1, Name = "Michele Tancorre", City = "Bari" },
        new Contact { Id = 2, Name = "Mario Rossi", City = "Napoli" },
        new Contact { Id = 3, Name = "Fabio Gialli", City = "Salerno" }
    };

    public void AddContact(Contact contact)
    {
        if (contact.Id == 0)
        {
            contact.Id = ContactList.Max(x => x.Id) + 1;
        }

        ContactList.Add(contact);
    }

    public void DeleteContact(int Id)
    {
        var c = ContactList.FirstOrDefault(x => x.Id == Id);

        if(c is not null)
        {
            ContactList.Remove(c);
        }
    }

    public IEnumerable<Contact>? GetContacts()
    {
        return ContactList;
    }

    public void UpdateContact(Contact contact)
    {
        var c = ContactList.FirstOrDefault(x => x.Id == contact.Id);
        if(c is not null)
        {
            c.City = contact.City;
            c.Name = contact.Name;
        }
    }
}
