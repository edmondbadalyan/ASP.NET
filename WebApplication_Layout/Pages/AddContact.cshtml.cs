using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication_Layout.Pages
{
    public class AddContactModel : PageModel
    {
        private readonly ContactService _contactService;

        [BindProperty]
        public Contact Contact { get; set; }

        public AddContactModel(ContactService contactService)
            =>_contactService = contactService;
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contactService.AddContact(Contact);
            return RedirectToPage("/ViewContacts");
        }
    }
}
