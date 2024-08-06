

namespace Blazor.Library.Contacts.Interfaces;

public interface IContact
{
    public IEnumerable<Contact>? GetContacts();
    public void AddContact(Contact contact);

    public void UpdateContact(Contact contact);
    
    public void DeleteContact(int Id);
}
