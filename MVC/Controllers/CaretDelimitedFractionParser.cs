using MVC.Models;

namespace MVC.Controllers
{
    public class CaretDelimitedFractionParser : IFractionParser
    {
        public Fraction Parse(string fileContent)
        {
            // Предполагается, что данные выглядят, например, так: "3^4"
            var parts = fileContent.Split('^');
            if (parts.Length != 2)
                throw new FormatException("Неверный формат файла. Ожидался разделитель '^'.");

            int numerator = int.Parse(parts[0].Trim());
            int denominator = int.Parse(parts[1].Trim());
            return new Fraction(numerator, denominator);
        }
    }
}
