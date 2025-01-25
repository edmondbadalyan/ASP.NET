using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Model;

namespace WebApplication2.Pages
{
    public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddProductModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
