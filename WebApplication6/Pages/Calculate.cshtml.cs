using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication6.Pages
{
    public class CalculateModel : PageModel
    {
        [BindProperty]
        public int Count { get; set; } = 1;

        [BindProperty]
        public List<Term> Terms { get; set; } = new List<Term>();

        public int Step { get; set; } = 1;

        public double Result { get; set; }

        public bool IsCalculated { get; set; } = false;

        public void OnGet()
        {
            // Начальная загрузка страницы – шаг 1.
            Step = 1;
        }

        /// <summary>
        /// Обработчик для шага 1: установка количества вычислений
        /// </summary>
        public IActionResult OnPostSetCount()
        {
            if (Count < 1)
            {
                ModelState.AddModelError("Count", "Количество должно быть больше 0.");
                return Page();
            }

            // Инициализация списка параметров с Count элементами.
            Terms = new List<Term>();
            for (int i = 0; i < Count; i++)
            {
                Terms.Add(new Term());
            }
            Step = 2;
            return Page();
        }

        public IActionResult OnPostCalculate()
        {
            Step = 2;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            double sum = 0.0;
            foreach (var term in Terms)
            {
                // Преобразуем угол из градусов в радианы.
                double thetaRadians = term.Theta * Math.PI / 180.0;
                double tanTheta = Math.Tan(thetaRadians);
                if (Math.Abs(tanTheta) < 1e-10)
                {
                    ModelState.AddModelError(string.Empty, "Ошибка: тангенс угла равен 0 (деление на ноль).");
                    return Page();
                }

                // Вычисляем X по формуле: X = Z^3 - B + A^2 / (tan(θ))^2
                double x = Math.Pow(term.Z, 3) - term.B + Math.Pow(term.A, 2) / Math.Pow(tanTheta, 2);
                sum += x;
            }
            Result = sum;
            IsCalculated = true;
            return Page();
        }
    }
    public class Term
    {
        public double A { get; set; }
        public double B { get; set; }
        public double Z { get; set; }
        public double Theta { get; set; }
    }
}
