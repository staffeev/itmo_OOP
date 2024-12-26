using System;
using System.Transactions;

public struct Point {
    // Класс точки в декартовой системе
    public double x, y;
    public static Point operator -(Point a, Point b)
    {
        return new Point
        {
            x = a.x - b.x,
            y = a.y - b.y
        };
    }
}

public class RandomNumber { 
    // Получение случайного числа, по модулю не превосходящего заданного
    public static double Get(int max_abs_value)
    {   
        var rnd = new Random();
        return Math.Sign(rnd.Next(-1, 1)) * rnd.Next(max_abs_value + 1);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Point target = new Point { x = RandomNumber.Get(2), y = RandomNumber.Get(2) };
        int total_sum = 0;
        Console.WriteLine("Type \'exit\' to quit the game");
        while (true)
        {
            try
            {

                double dist = Program.GetDistance(target);
                if (dist > 9) Console.WriteLine("Не попал! Сумма очков - {0}", total_sum);
                else
                {
                    if (dist <= 1) total_sum += 10;
                    else if (dist <= 4) total_sum += 5;
                    else total_sum += 1;
                    Console.WriteLine("Попал! Сумма очков - {0}", total_sum);
                }
            }
            catch (ArgumentException) { break; }
            catch (Exception e)
            {
                Console.WriteLine("An error occuried: {0}", e.Message);
                continue;
            }

        }
        Console.WriteLine("Сумма очков за игру - {0}", total_sum);
    }

    static double GetDistance(Point target) {
        // Получение точки от игрока и подсчет квадрата расстояния до
        // центра мишени
        Console.Write("x=");
        string command = Console.ReadLine();
        if (command == "exit") throw new ArgumentException();
        double x = double.Parse(command);
        Console.Write("y=");
        double y = double.Parse(Console.ReadLine());
        Point user = new Point { x = x + RandomNumber.Get(1), y = y + RandomNumber.Get(1) };
        Point diff = user - target;
        return diff.x * diff.x + diff.y * diff.y;
    }
}