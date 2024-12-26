using System;
using System.ComponentModel;

class ProcessArray
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter massive length");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Input(array);
            Console.WriteLine("Сумма элементов равна {0}", Sum(array));
            Console.WriteLine("Сумма положительных элементов равна {0}", Sum(array, true));
            Console.WriteLine("Сумма отрицательных элементов равна {0}", Sum(array, false));
            Console.WriteLine("Сумма элементов на четных местах равна {0}", Sum(array, "even"));
            Console.WriteLine("Сумма элементов на нечетных местах равна {0}", Sum(array, "odd"));
            int x1, x2;
            GetMaxMinIndexes(array, out x1, out x2);
            Console.WriteLine("Индексы минимального и максимального элементов - {0} и {1}", x1, x2);
            Console.WriteLine("Перемножение элементов между максимальным и минимальным равно {0}",
                MultiplyBetweenMinMax(array));

        }
        catch (FormatException e)
        {
            Console.WriteLine("Ошибка формата: {0}", e.Message);
        }
        catch (Exception e) {
            Console.WriteLine("Элементы массива слишком большие, чтобы посчитать их перемножение");
        }
            
    }
    private static void Input(int[] a)
    { // ввод элементов массива
        for (int i = 0; i < a.GetLength(0); i++)
        {
            Console.Write("a[{0}]=", i);
            a[i] = int.Parse(Console.ReadLine());
        }
    }
    private static long Sum(int[] a) { 
        // сумма элементов
        long sum = 0;
        foreach (int i in a) sum += i;
        return sum;
    }
    private static double Mean(int[] a) { 
        // среднее значение
        double sum = Sum(a);
        return sum / a.Length;
    }
    private static long Sum(int[] a, bool flag) {
        // сумма положительных (flag=true) или отрицательных (flag=false) элементов
        long sum = 0;
        foreach (int x in a) {
            if (flag && x > 0 || !flag && x < 0) sum += x;
        }
        return sum;
    }
    private static long Sum(int[] a, string flag)
    {
        // сумма элементов на нечетных (flag='odd') или четных (flag='even') позициях
        long sum = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (flag == "odd" && i % 2 != 0) sum += a[i];
            else if (flag == "even" && i % 2 == 0) sum += a[i];
        }
        return sum;
    }
    private static void GetMaxMinIndexes(int[] a, out int xmin, out int xmax) { 
        // получение индексов минимального и максимального элемента
        xmin = 0; xmax = 0;
        long min = int.MaxValue; long max = int.MinValue;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] < min) { min = a[i]; xmin = i; }
            if (a[i] > max) { max = a[i]; xmax = i; }
        }
    }
    private static long MultiplyBetweenMinMax(int[] a) {
        // умножение всех элементов между минимальным и максимальным
        int xmin, xmax;
        long mult = 1;
        GetMaxMinIndexes(a, out xmin, out xmax);
        checked // вдруг будет переполнение
        {
            for (int i = Math.Min(xmin, xmax) + 1; i < Math.Max(xmin, xmax); i++)
            {
                mult *= a[i];
            }
        }
        return mult;
    }
}