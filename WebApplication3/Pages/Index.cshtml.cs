using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public int CurrentDayOfYear { get; private set; }
        private static readonly Random _random = new();
        public char RandomLetter { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            CurrentDayOfYear = DateTime.Now.DayOfYear;
            
            RandomLetter = (char)('A' + _random.Next(0, 26));
        }
    }
}
