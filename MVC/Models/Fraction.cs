namespace MVC.Models
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction() { }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            Numerator = numerator;
            Denominator = denominator;
        }

        // Сложение
        public Fraction Add(Fraction other)
        {
            int numerator = this.Numerator * other.Denominator + other.Numerator * this.Denominator;
            int denominator = this.Denominator * other.Denominator;
            return new Fraction(numerator, denominator).Reduce();
        }

        // Вычитание
        public Fraction Subtract(Fraction other)
        {
            int numerator = this.Numerator * other.Denominator - other.Numerator * this.Denominator;
            int denominator = this.Denominator * other.Denominator;
            return new Fraction(numerator, denominator).Reduce();
        }

        // Умножение
        public Fraction Multiply(Fraction other)
        {
            int numerator = this.Numerator * other.Numerator;
            int denominator = this.Denominator * other.Denominator;
            return new Fraction(numerator, denominator).Reduce();
        }

        // Деление
        public Fraction Divide(Fraction other)
        {
            if (other.Numerator == 0)
                throw new DivideByZeroException("Нельзя делить на дробь с нулевым числителем.");
            int numerator = this.Numerator * other.Denominator;
            int denominator = this.Denominator * other.Numerator;
            return new Fraction(numerator, denominator).Reduce();
        }

        // Сокращение дроби
        public Fraction Reduce()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            // Для сохранения знака знаменателя положительным можно добавить дополнительную логику
            return new Fraction(Numerator / gcd, Denominator / gcd);
        }

        // Нахождение НОД (наибольшего общего делителя)
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        // Представление дроби в виде десятичной дроби
        public decimal ToDecimal()
        {
            return (decimal)Numerator / Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}

