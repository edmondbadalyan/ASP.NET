using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class SumPageModel : PageModel
    {
        [BindProperty]
        public int N { get; set; }

        [BindProperty]
        public int K { get; set; }

        public double Result { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (N < 1 || K < 0)
            {
                ErrorMessage = "N должно быть не менее 1, а K — неотрицательным числом.";
                return Page();
            }

            Result = 0;
            for (int i = 1; i <= N; i++)
            {
                Result += Math.Pow(i, K);
            }

            return Page();
        }
    }
}
