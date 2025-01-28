using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class AnglePageModel : PageModel
    {
        private const double G = 9.81; // Ускорение свободного падения

        [BindProperty]
        public double V { get; set; } // Начальная скорость

        [BindProperty]
        public double T { get; set; } // Время полета

        public double? AngleDegrees { get; set; } // Угол в градусах
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

            if (V <= 0 || T <= 0)
            {
                ErrorMessage = "Скорость и время должны быть положительными числами!";
                return Page();
            }

            double argument = G * T / (2 * V);

            if (Math.Abs(argument) > 1)
            {
                ErrorMessage = "Невозможно определить угол: недопустимые параметры (gT/2V > 1)";
                return Page();
            }

            // Вычисляем угол в радианах и переводим в градусы
            double angleRadians = Math.Asin(argument);
            AngleDegrees = angleRadians * (180 / Math.PI);

            return Page();
        }
    }
}
