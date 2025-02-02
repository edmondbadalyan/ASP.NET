namespace MVC.Controllers
{
    public static class FractionParserFactory
    {
        public static IFractionParser GetParser(string fileContent)
        {
            if (fileContent.Contains("+"))
            {
                return new PlusDelimitedFractionParser();
            }
            else if (fileContent.Contains("^"))
            {
                return new CaretDelimitedFractionParser();
            }
            else
            {
                throw new NotSupportedException("Формат файла не поддерживается. Не найден подходящий разделитель.");
            }
        }
    }
}
