using System;

class MatrixMultiply {
    public static void Main(string[] args)
    {
        try
        {
            int n1, m1, n2, m2;
            // ввод первой матрицы
            Console.Write("Enter number of rows in matrix A: ");
            n1 = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns in matrix A: ");
            m1 = int.Parse(Console.ReadLine());
            int[,] a = new int[n1, m1];
            Input(a);
            // ввод второй матрицы
            Console.Write("Enter number of rows in matrix B: ");
            n2 = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns in matrix B: ");
            m2 = int.Parse(Console.ReadLine());
            int[,] b = new int[n2, m2];
            Input(b);
            // перемножение
            int[,] result = Multiply(a, b);
            Output(result);
        }
        catch (ArgumentException e) { // матрицы неподходящих размеров
            Console.WriteLine("Размеры введенных матриц не позволяют их перемножить");
        }
    }

    private static void Input(int[,] a)
    { // ввод элементов матрицы
        for (int row = 0; row < a.GetLength(0); row++)
        {
            for (int col = 0; col < a.GetLength(1); col++)
            {
                Console.Write("Enter value for [{0},{1}] : ", row, col);
                a[row, col] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
    }

    private static int[,] Multiply(int[,] a, int[,] b)
    { // перемножение матриц
        if (a.GetLength(1) != b.GetLength(0)) throw new ArgumentException();
        int[,] result = new int[a.GetLength(0), b.GetLength(1)];
        for (int row = 0; row < a.GetLength(0); row++) {
            for (int col = 0; col < b.GetLength(1); col++) {
                for (int i = 0; i < a.GetLength(1); i++) {
                    result[row, col] += a[row, i] * b[i, col];
                }
            }
        }
        return result;
    }

    private static void Output(int[,] result)
    { // вывод матрицы
        for (int row = 0; row < result.GetLength(0); row++) {
            for (int col = 0; col < result.GetLength(1); col++) {
                Console.Write("{0} ", result[row, col]);
            }
            Console.WriteLine();
        }
    }
}