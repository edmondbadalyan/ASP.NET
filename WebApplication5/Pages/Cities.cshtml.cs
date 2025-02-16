using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Pages
{
    public class CitiesModel : PageModel
    {
        private readonly AppDbContext _context;

        public CitiesModel(AppDbContext context) => _context = context;

        public IList<string> Cities { get; set; }

        public async Task OnGetAsync() =>
            Cities = await _context.Customers.Select(c => c.City).Distinct().ToListAsync();
    }
}
