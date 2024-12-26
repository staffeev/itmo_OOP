using System;

class Program {
    static void Main(string[] args) {
        try {
            Console.Write("x=");
            float x = float.Parse(Console.ReadLine());
            Console.Write("y=");
            float y = float.Parse(Console.ReadLine());
            // проверка условий
            if (x * x + y * y < 9 && y > 0) { Console.WriteLine("Внутри"); }
            else if (x * x + y * y == 9 && y >= 0) { Console.WriteLine("На границе"); }
            else { Console.WriteLine("Вне"); }
        }
        catch (FormatException e)
        {
            Console.WriteLine("A format error has occuried:", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An unexpected error has occuried:", e.Message);
        }
    }
}