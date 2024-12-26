using System;

class Program {
    public static void Main(string[] args)
    {
        int[] array;
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        array = new int[n];
        for (int i = 0; i < array.Length; i++) { 
            Console.Write("array[{0}]=", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        foreach (int x in array) Console.Write("{0} ", (x % 2 == 0) ? 0 : x);
    }
}