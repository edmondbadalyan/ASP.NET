using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Layout.Pages
{
    public class SumCalculatorModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "¬ведите число")]
        [Range(1, 1000, ErrorMessage = "„исло должно быть от 1 до 1000")]
        public int N { get; set; }

        public double Result { get; set; }
        public bool HasResult { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (!ModelState.IsValid) return;

            double totalSum = 0.0;
            double currentSinSum = 0.0;

            for (int k = 1; k <= N; k++)
            {
                currentSinSum += Math.Sin(k); // јргумент в радианах
                totalSum += 1.0 / currentSinSum;
            }

            Result = totalSum;
            HasResult = true;
        }
    }
}
