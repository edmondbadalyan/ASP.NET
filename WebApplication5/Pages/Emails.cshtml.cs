using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Pages
{
    public class EmailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public EmailsModel(AppDbContext context) => _context = context;

        public IList<string> Emails { get; set; }

        public async Task OnGetAsync() =>
            Emails = await _context.Customers.Select(c => c.Email).ToListAsync();
    }
}
