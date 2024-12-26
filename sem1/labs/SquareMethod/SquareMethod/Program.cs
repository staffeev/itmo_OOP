using System;

class Operation
{
    static void IsTriangle(double a, double b, double c) {
        // проверка на треугольник
        if (!(a < b + c && b < a + c && c < a + b)) {
            throw new ArgumentException();
        }
    }
    public static double Square(double a, double b, double c)
    {
        // расчет площади
        Operation.IsTriangle(a, b, c);
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static double Square(double a) {
        // расчет площади равностороннего треугольника
        Operation.IsTriangle(a, a, a);
        return a * a * Math.Sqrt(3) / 4;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        double square;
        try
        {
            Console.WriteLine("Введите тип треугольника - равносторонний (true) или нет (false)");
            bool type = bool.Parse(Console.ReadLine());
            if (type) {
                Console.Write("Введите значение стороны - ");
                double a = double.Parse(Console.ReadLine());
                square = Operation.Square(a);
                Console.WriteLine("Сторона - {0}, площадь - {1:f3}", a, square);

            }
            else {
                Console.Write("Введите значение первой стороны - ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введите значение второй стороны - ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Введите значение третьей стороны - ");
                double c = double.Parse(Console.ReadLine());
                square = Operation.Square(a, b, c);
                Console.WriteLine("Стороны равны {0}, {1} и {2}. Площадь равна {3:f3}", a, b, c, square);
            }
        }
        catch (ArgumentException e) { Console.WriteLine("Не существует треугольника с указанными сторонами"); }
        catch (FormatException e) { Console.WriteLine("Данные введены в неверном формате: {0}", e.Message); }
    }
}