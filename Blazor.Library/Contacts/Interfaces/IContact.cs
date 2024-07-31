

namespace Blazor.Library.Contacts.Interfaces;

public interface IContact
{
    public IEnumerable<Contact>? GetContacts();
    public void AddContact(Contact contact);
}
