using System;

class Program {
    static void Main(string[] args) {
        try {
            Console.Write("k=");
            int k = int.Parse(Console.ReadLine());
            Console.Write("m=");
            int m = int.Parse(Console.ReadLine());
            // если k и m не в нужном диапазоне
            if (!(1 <= k && k <= m && m <= 100)) { throw new ArithmeticException(); }
            int sum = 0;
            for (int i = 1; i <= 100; i++) {
                if (i > k && i < m) continue;
                sum+=i;
            }
            Console.WriteLine("Сумма равна {0}", sum);
        }
        catch (ArithmeticException e)
        {
            Console.WriteLine("Числа k и m должны удовлетворять условию 1 <= k <= m <= 100");
        }
    }
}