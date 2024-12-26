using System;

class Program {
    static void Main(string[] args)
    {
        Console.Write("A = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("OP = ");
        char op = char.Parse(Console.ReadLine());
        Console.Write("B = ");
        double b = double.Parse(Console.ReadLine());
        bool ok = true;
        double res = 0;
        // вычисления на "калькуляторе"
        switch (op)
        {
            case '+': res = a + b; break;
            case '-': res = a - b; break;
            case '*': res = a * b; break;
            case '/':
            case ':': res = a / b; break;
            default: ok = false; break;
        }
        // вывод результата
        if (!ok) { Console.WriteLine("Error! Available operations are +, -, * and / (:)"); }
        else { Console.WriteLine("{0} {1} {2} = {3}", a, op, b, res); }
    }
}