namespace WebApplication2
{
    public class HomeWork_Zadanie_3
    {
        static void Main()
        {
            Console.WriteLine("Конвертер десятичных чисел");
            Console.WriteLine("--------------------------");

            int number;
            while (true)
            {
                Console.Write("Введите целое число: ");
                if (int.TryParse(Console.ReadLine(), out number))
                    break;
                Console.WriteLine("Ошибка: Введите корректное целое число!\n");
            }

            Console.WriteLine("\nРезультаты преобразования:");
            Console.WriteLine($"Двоичная:  {Convert.ToString(number, 2)}");
            Console.WriteLine($"Восьмеричная:  {Convert.ToString(number, 8)}");
            Console.WriteLine($"Шестнадцатеричная:  {Convert.ToString(number, 16).ToUpper()}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
