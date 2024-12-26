using System;

class SquareOfTriange {
    static void Main(string[] args) {
        try {
            Console.WriteLine("Enter the perimeter of triangle:");
            double perimeter = double.Parse(Console.ReadLine());
            if (perimeter <= 0) {   // периметр может быть только положительным
                throw new FormatException();
            }
            // вычисление площади
            double square = perimeter * perimeter * Math.Sqrt(3) / 36;
            // вывод таблицы с результатами
            Console.WriteLine("\n{0,-10} | {1,-10}", "Сторона", "Площадь");
            Console.WriteLine("{0,-10:f2} | {1,-10:f2}", perimeter / 3, square);
        }
        catch (FormatException e) // обработка неверных входных данных
        {
            Console.WriteLine("The input data must be a positibe number");
        }
        catch (Exception e)
        {
            Console.WriteLine("The unexpected error has occuried: {0}", e.Message);
        }
    }
}