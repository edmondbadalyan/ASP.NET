using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Вводите только цифры (0-9)")]
        public string Sequence { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Позиция должна быть больше 0")]
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
                Error = $"Позиция {Position} превышает длину последовательности ({Sequence.Length})";
                return Page();
            }

            // Получаем цифру (индекс начинается с 0)
            char digit = Sequence[Position - 1];
            Result = $"Цифра на позиции {Position}: {digit}";

            return Page();
        }
    }
}
