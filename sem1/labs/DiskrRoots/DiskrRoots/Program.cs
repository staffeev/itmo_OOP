using System;
using System.Numerics;

class Solver {

    public static int GetRoots(double a, double b, double c, ref double x1, ref double x2) {
        double D = b * b - 4 * a * c;
        if (D < 0) return -1;
        x1 = (-b - Math.Sqrt(D)) / (2 * a);
        x2 = (-b + Math.Sqrt(D)) / (2 * a);
        return (x1 == x2) ? 0 : 1;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        double x1 = 0, x2 = 0;
        Console.WriteLine("Введите коэффициенты квадратного уравнения:");
        Console.Write("a=");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b=");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c=");
        double c = double.Parse(Console.ReadLine());
        int res = Solver.GetRoots(a, b, c, ref x1, ref x2);
        if (res == -1) { // корней нет
            Console.WriteLine("Корней уравнения с коэффициентами a = {0}, b = {1}, c = {2} нет.", a, b, c);
        }
        else if (res == 0) { // один корень
            Console.WriteLine("Корень уравнения с коэффициентами a = {0}, b = {1}, c = {2} равен x1 = x2 = {3:f4}", 
                a, b, c, x1);
        }
        else { // два корня
            Console.WriteLine("Корни уравнения с коэффициентами a = {0}, b = {1}, c = {2} равны x1 = {3:f4}, x2 = {4:f4}", 
                a, b, c, x1, x2);
        }
    }
}