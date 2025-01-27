using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_Layout.Pages
{
    public class ViewContactsModel : PageModel
    {
        private readonly ContactService _contactService;

        public ViewContactsModel(ContactService contactService)
            => _contactService = contactService;

        public List<Contact> Contacts => _contactService.Contacts;
        public void OnGet()
        {
        }
    }
}
