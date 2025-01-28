using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        [Required(ErrorMessage = "���� ����������� ��� ����������")]
        [RegularExpression(@"^\d+$", ErrorMessage = "������� ������ ����� (0-9)")]
        public string Sequence { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "���� ����������� ��� ����������")]
        [Range(1, int.MaxValue, ErrorMessage = "������� ������ ���� ������ 0")]
        public int Position { get; set; }

        public string Result { get; set; }
        public string Error { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Position > Sequence.Length)
            {
                Error = $"������� {Position} ��������� ����� ������������������ ({Sequence.Length})";
                return Page();
            }

            // �������� ����� (������ ���������� � 0)
            char digit = Sequence[Position - 1];
            Result = $"����� �� ������� {Position}: {digit}";

            return Page();
        }
    }
}
