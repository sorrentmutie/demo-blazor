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
        ContactList.Add(contact);
    }

    public IEnumerable<Contact>? GetContacts()
    {
        return ContactList;
    }
}
