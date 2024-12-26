interface IProgression {
    double firstElement { get; set; }
    double shift { get; set;}
    double GetElement(int k);
}

class ArithmeticProgression : IProgression {
    public double firstElement { get; set; }
    public double shift { get; set; }
    public double GetElement(int k) { 
        return firstElement + (k - 1) * shift;
    }
}

class GeometricProgression : IProgression
{
    public double firstElement { get; set; }
    public double shift { get; set; }
    public double GetElement(int k)
    {
        return firstElement * Math.Pow(shift, k - 1);
    }
}


class Program {
    public static void Main(string[] args) {
        Console.Write("a0=");
        double a0 = double.Parse(Console.ReadLine());
        Console.Write("d=");
        double d = double.Parse(Console.ReadLine());
        ArithmeticProgression arprog = new ArithmeticProgression();
        arprog.shift = d; arprog.firstElement = a0;
        Console.Write("k=");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("k-й член арифметической прогрессии равен {0}", arprog.GetElement(k));

        Console.Write("b0=");
        double b0 = double.Parse(Console.ReadLine());
        Console.Write("q=");
        double q = double.Parse(Console.ReadLine());
        GeometricProgression geoprog = new GeometricProgression();
        geoprog.shift = q; geoprog.firstElement = b0;
        Console.Write("k=");
        k = int.Parse(Console.ReadLine());
        Console.WriteLine("k-й член геометрической прогрессии равен {0}", arprog.GetElement(k));


    }
}