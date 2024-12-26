using System;

class Program {
    public static void Main(string[] args) {
        Console.Write("n=");
        int n = 2 * int.Parse(Console.ReadLine());
        // while cycle
        Console.WriteLine("Cycle WHILE works:");
        int i = 1;
        while (i <= n) {
            Console.Write(i + " ");
            i += 2;
        }
        // do while cycle
        Console.WriteLine("\nCycle DO WHILE works:");
        i = 1;
        do { 
            Console.Write(i + " ");
            i += 2;
        } while (i <= n);
        // for cycle
        Console.WriteLine("\nCycle FOR works:");
        for (i = 1; i <= n; i+= 2)
        {
            Console.Write(i + " ");
        }
    }
}