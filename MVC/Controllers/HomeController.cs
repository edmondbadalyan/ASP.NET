using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Fraction
        public ActionResult Index()
        {
            return View(new FractionOperationViewModel());
        }
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Файл не выбран или пуст.");
                return View();
            }

            string content;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                content = await reader.ReadToEndAsync();
            }

            try
            {
                // Получаем подходящий парсер по содержимому файла
                var parser = FractionParserFactory.GetParser(content);
                // Разбираем данные файла и получаем объект Fraction
                Fraction fraction = parser.Parse(content);

                ViewBag.Message = $"Загружена дробь: {fraction}  (Десятичное значение: {fraction.ToDecimal()})";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }




        [HttpPost]
        public ActionResult Calculate(FractionOperationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                // Создаём первую дробь
                Fraction fraction1 = new Fraction(model.Numerator1, model.Denominator1);
                Fraction result = null;

                // Выполнение операции в зависимости от выбранного значения
                switch (model.Operation)
                {
                    case "add":
                        {
                            Fraction fraction2 = new Fraction(model.Numerator2, model.Denominator2);
                            result = fraction1.Add(fraction2);
                            break;
                        }
                    case "subtract":
                        {
                            Fraction fraction2 = new Fraction(model.Numerator2, model.Denominator2);
                            result = fraction1.Subtract(fraction2);
                            break;
                        }
                    case "multiply":
                        {
                            Fraction fraction2 = new Fraction(model.Numerator2, model.Denominator2);
                            result = fraction1.Multiply(fraction2);
                            break;
                        }
                    case "divide":
                        {
                            Fraction fraction2 = new Fraction(model.Numerator2, model.Denominator2);
                            result = fraction1.Divide(fraction2);
                            break;
                        }
                    case "reduce":
                        {
                            // При сокращении используется только первая дробь
                            result = fraction1.Reduce();
                            break;
                        }
                    default:
                        ModelState.AddModelError("", "Неизвестная операция");
                        return View("Index", model);
                }

                model.ResultFraction = result.ToString();
                model.ResultDecimal = result.ToDecimal();

                return View("Index", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Index", model);
            }
        }
    }
}
