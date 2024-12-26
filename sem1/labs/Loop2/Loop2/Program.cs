using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("x1=");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("x2=");
        double x2 = double.Parse(Console.ReadLine());
        double x = x1;
        Console.WriteLine("{0,-10} | {1,-10}", "x", "y");
        do
        {
            double y = Math.Sin(x);
            Console.WriteLine("{0,-10:f2} | {1,-10:f4}", x, y);
            x += 0.01;
        } while (x <= x2);
    }
}