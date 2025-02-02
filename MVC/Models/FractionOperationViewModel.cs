using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class FractionOperationViewModel
    {
        [Display(Name = "Числитель 1")]
        public int Numerator1 { get; set; }

        [Display(Name = "Знаменатель 1")]
        public int Denominator1 { get; set; }

        [Display(Name = "Числитель 2")]
        public int Numerator2 { get; set; }

        [Display(Name = "Знаменатель 2")]
        public int Denominator2 { get; set; }

        // Значения: "add", "subtract", "multiply", "divide", "reduce"
        public string Operation { get; set; }

        // Результат операции в виде строки (обычная дробь)
        public string? ResultFraction { get; set; }

        // Результат операции в виде десятичной дроби
        public decimal ResultDecimal { get; set; }
    }
}

