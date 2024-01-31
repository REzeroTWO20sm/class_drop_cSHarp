using System;

namespace FractionExample
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                denominator = value;
            }
        }

        public double DecimalValue
        {
            get { return (double)numerator / denominator; }
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Add(Fraction other)
        {
            int num = numerator * other.denominator + other.numerator * denominator;
            int den = denominator * other.denominator;
            return new Fraction(num, den);
        }

        public Fraction Subtract(Fraction other)
        {
            int num = numerator * other.denominator - other.numerator * denominator;
            int den = denominator * other.denominator;
            return new Fraction(num, den);
        }

        public Fraction Multiply(Fraction other)
        {
            int num = numerator * other.numerator;
            int den = denominator * other.denominator;
            return new Fraction(num, den);
        }

        public Fraction Divide(Fraction other)
        {
            if (other.numerator == 0)
                throw new ArgumentException("Деление на ноль запрещено");
            int num = numerator * other.denominator;
            int den = denominator * other.numerator;
            return new Fraction(num, den);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Fraction f1 = new Fraction(1, 2);
                Fraction f2 = new Fraction(3, 4);
                Fraction sum = f1.Add(f2);
                Fraction diff = f1.Subtract(f2);
                Fraction prod = f1.Multiply(f2);
                Fraction div = f1.Divide(f2);

                Console.WriteLine("Сумма: {0}/{1}", sum.Numerator, sum.Denominator);
                Console.WriteLine("Разность: {0}/{1}", diff.Numerator, diff.Denominator);
                Console.WriteLine("Произведение: {0}/{1}", prod.Numerator, prod.Denominator);
                Console.WriteLine("Частное: {0}/{1}", div.Numerator, div.Denominator);
                Console.WriteLine("Десятичная дробь: {0}", div.DecimalValue);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }

            Console.ReadLine();
        }
    }
}
/*
Поля класса "Fraction":
- numerator (числитель) - используется для хранения значения числителя дроби.
- denominator (знаменатель) - используется для хранения значения знаменателя дроби.

Свойства класса "Fraction":
- Numerator (Числитель) - позволяет получить или задать значение числителя дроби.
- Denominator (Знаменатель) - позволяет получить или задать значение знаменателя дроби. В сеттере свойства также содержится проверка, чтобы знаменатель не был равен 0. Если значение 0 передано, генерируется исключение ArgumentException с сообщением "Знаменатель не может быть равен 0".

Методы класса "Fraction":
- Add (Сложение) - принимает другой объект класса "Fraction" и возвращает новый объект, представляющий сумму двух дробей.
- Subtract (Вычитание) - принимает другой объект класса "Fraction" и возвращает новый объект, представляющий разность двух дробей.
- Multiply (Умножение) - принимает другой объект класса "Fraction" и возвращает новый объект, представляющий произведение двух дробей.
- Divide (Деление) - принимает другой объект класса "Fraction" и возвращает новый объект, представляющий частное двух дробей. Этот метод также содержит проверку, чтобы знаменатель второй дроби не был равен 0. Если это условие нарушается, выбрасывается исключение ArgumentException с сообщением "Деление на ноль запрещено".

В функции Main создаются два объекта класса "Fraction" (f1 и f2), а затем выполняются арифметические операции над этими объектами, используя методы Add, Subtract, Multiply и Divide. Результаты операций выводятся на консоль.

Если происходят исключения во время выполнения операций (например, деление на 0), они перехватываются с использованием блока try-catch в функции Main, и сообщение об ошибке выводится на консоль.
*/