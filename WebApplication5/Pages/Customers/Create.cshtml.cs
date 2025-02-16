using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public SelectList Categories { get; set; }

        [BindProperty]
        public List<int> SelectedCategories { get; set; }

        public async Task OnGetAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            Categories = new SelectList(categories, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Customer.CustomerCategories = SelectedCategories
                .Select(catId => new CustomerCategory
                {
                    Customer = Customer,
                    CategoryId = catId
                })
                .ToList();

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
