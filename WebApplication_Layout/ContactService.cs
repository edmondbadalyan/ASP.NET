namespace WebApplication_Layout
{
    public class ContactService
    {
        public List<Contact> Contacts { get; } = new();

        public void AddContact(Contact contact) => Contacts.Add(contact);
    }
}
