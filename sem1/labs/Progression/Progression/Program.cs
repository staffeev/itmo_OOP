using System;

abstract class Progression {
    private protected double firstElement;
    private protected double shift;

    public Progression() { }
    public Progression(double firstElement, double shift)
    { // конструктор
        this.firstElement = firstElement;
        this.shift = shift;
    }
    abstract public double GetElement(int k);
}


class ArithmeticProgression : Progression {

    public ArithmeticProgression(double firstElement, double shift) : base(firstElement, shift) { }
    public override double GetElement(int k)
    { // получение k-го члена
        return firstElement + (k - 1) * shift;
    }
}

class GeometricProgression : Progression {
    public GeometricProgression(double firstElement, double shift) : base(firstElement, shift) { }
    public override double GetElement(int k)
    { // получение k-го члена
        checked
        {
            return firstElement * Math.Pow(shift, k - 1);
        }
    }
}

class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Введите первый член арифметической прогресси:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите шаг арифметической прогресси:");
        double d = double.Parse(Console.ReadLine());
        ArithmeticProgression arprog = new ArithmeticProgression(a, d);
        Console.WriteLine("Введите k - номер искомого члена прогрессии");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("k-й член арифметической прогрессии равен {0}\n", arprog.GetElement(k));

        Console.WriteLine("Введите первый член геометрической прогресси:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите знаменатель геометрической прогресси:");
        double q = double.Parse(Console.ReadLine());
        GeometricProgression geoprog = new GeometricProgression(b, q);
        Console.WriteLine("Введите k - номер искомого члена прогрессии");
        k = int.Parse(Console.ReadLine());
        Console.WriteLine("k-й член геометрической прогрессии равен {0}", geoprog.GetElement(k));
    }
}