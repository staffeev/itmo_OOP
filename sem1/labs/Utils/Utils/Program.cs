using System;

class Utils {
    public static int Greater(int a, int b) { 
        return (a > b) ? a : b; 
    }
    public static bool Factorial(int n, out int answer) {
        int counter;
        int value = 1;
        bool flag = true;
        try
        {
            checked
            {
                for (counter = 2; counter <= n; counter++)
                {
                    value *= counter;
                }
            }
        }
        catch (Exception)
        {
            flag = false;
            value = 0;
        }
        answer = value;
        return flag;
    }
}

class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Введите первое число:");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        int y = int.Parse(Console.ReadLine());
        Console.WriteLine("Большим из чисел {0} и {1} является {2}", x, y, Utils.Greater(x, y));
    }
    //public static void Main(string[] args) {
    //    bool flag;
    //    int res;
    //    Console.Write("n=");
    //    int n = int.Parse(Console.ReadLine());
    //    flag = Utils.Factorial(n, out res);
    //    if (flag) { Console.WriteLine("Factorial of {0} is {1}", n, res); }
    //    else { Console.WriteLine("Cannot calculate factorial of {0}", n); }
    //}
}