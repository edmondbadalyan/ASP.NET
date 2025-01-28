using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class AnglePageModel : PageModel
    {
        private const double G = 9.81; // ��������� ���������� �������

        [BindProperty]
        public double V { get; set; } // ��������� ��������

        [BindProperty]
        public double T { get; set; } // ����� ������

        public double? AngleDegrees { get; set; } // ���� � ��������
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
                ErrorMessage = "�������� � ����� ������ ���� �������������� �������!";
                return Page();
            }

            double argument = G * T / (2 * V);

            if (Math.Abs(argument) > 1)
            {
                ErrorMessage = "���������� ���������� ����: ������������ ��������� (gT/2V > 1)";
                return Page();
            }

            // ��������� ���� � �������� � ��������� � �������
            double angleRadians = Math.Asin(argument);
            AngleDegrees = angleRadians * (180 / Math.PI);

            return Page();
        }
    }
}
