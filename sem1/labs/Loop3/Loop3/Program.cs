using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("a=");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b=");
        int b = int.Parse(Console.ReadLine());
        int temp = a;
        do
        {
            a = temp;
            if (a < b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            temp = a - b;
            a = b;
        } while (temp != b);
        Console.WriteLine("НОД - {0}", b);
    }
}