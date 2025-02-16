using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public string CityFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CountryFilter { get; set; }

        public IList<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Customers
                .Include(c => c.CustomerCategories)
                .ThenInclude(cc => cc.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(CityFilter))
                query = query.Where(c => c.City == CityFilter);

            if (!string.IsNullOrEmpty(CountryFilter))
                query = query.Where(c => c.Country == CountryFilter);

            Customers = await query.ToListAsync();
        }
    }
}
