namespace WebApplication2
{
    public class HomeWork_Zadanie_2
    {
        static void Main()
        {
            
            Console.Write("Введите значение c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите значение d: ");
            double d = Convert.ToDouble(Console.ReadLine());

            double sum = 0;

            // Цикл вычислений для i от 1 до 10
            for (int i = 1; i <= 10; i++)
            {
                double a = (c + d) * i;
                double b = (c - d) * i;

                
                sum += Ample(a, b);
            }

            // Вычисление среднего арифметического
            double average = sum / 10;
            Console.WriteLine($"Среднее значение: {average:F2}");
        }

        // Функция вычисления квадратного корня суммы квадратов целых частей
        static double Ample(double a, double b)
        {
            int aInt = (int)Math.Floor(a); // Целая часть a
            int bInt = (int)Math.Floor(b); // Целая часть b

            return Math.Sqrt(aInt * aInt + bInt * bInt);
        }
    }
}
