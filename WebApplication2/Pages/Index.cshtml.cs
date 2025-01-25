using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Letter { get; set; }

        [BindProperty]
        public string UserText { get; set; }

        public int Count { get; set; }
        public char TargetChar { get; set; }
        public bool ShowResults { get; set; }

        private readonly string _defaultText = "Вот дом, Который построил Джек...";

        public void OnGet()
        {
            UserText = _defaultText;
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Letter) || Letter.Length == 0)
                return Page();

            TargetChar = Letter.ToLower()[0];
            var text = !string.IsNullOrEmpty(UserText) ? UserText : _defaultText;

            Count = text.Count(c =>
                char.IsLetter(c) &&
                char.ToLower(c) == TargetChar
            );

            ShowResults = true;
            return Page();
        }
    }
}
