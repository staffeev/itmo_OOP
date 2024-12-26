using System;

public struct Distance {
    public ulong ft;
    public ulong inch;

    public static Distance operator +(Distance x, Distance y)
    {
        return new Distance
        {
            ft = x.ft + y.ft,
            inch = x.inch + y.inch
        };
    }

    public void ReCalculate() {
        ft = ft + inch / 12;
        inch = inch % 12;
    }
}


class Program {
    static void Main(string[] args) {
        try {
            Distance dist1, dist2;
            Console.WriteLine("Enter distance 1 fts:");
            dist1.ft = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Enter distance 1 inches:");
            dist1.inch = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Enter distance 2 fts:");
            dist2.ft = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Enter distance 2 inches:");
            dist2.inch = ulong.Parse(Console.ReadLine());
            Distance dist3 = dist1 + dist2;
            dist3.ReCalculate();
            Console.WriteLine("Total distance is {0}\'-{1}\"", dist3.ft, dist3.inch);
        }
        catch (FormatException e)
        {
            Console.WriteLine("Input data must be positive integer.");
        }
        catch (Exception e)
        {
            Console.WriteLine("An unexpected error has occuried: {0}", e.Message);
        }
    }
}
