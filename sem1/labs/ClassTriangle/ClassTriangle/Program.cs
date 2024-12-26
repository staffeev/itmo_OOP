using System;

class Triangle
{
    private double a, b, c;
    public Triangle() { }
    public Triangle(double a, double b, double c)
    {
        // конструктор
        if (!Triangle.IsTriangle(a, b, c)) throw new ArgumentException();
        this.a = a; this.b = b; this.c = c;
    }
    public Triangle(double a)
    {
        // перегрузка: равносторонний треугольник
        if (a <= 0) throw new ArgumentException();
        this.a = a; this.b = a; this.c = a;
    }
    public void Show()
    {
        // вывод информции о треугольнике
        if (this.a == this.b && this.b == this.c)
        {
            Console.WriteLine("Сторона равностороннего треугольника равна {0}", this.a);
        }
        else
        {
            Console.WriteLine("Стороны треугольника равны {0}, {1} и {2}", this.a, this.b, this.c);
        }
        Console.WriteLine("Периметр: {0}", Perimeter());
        Console.WriteLine("Площадь: {0:f4}", Square());
        Console.WriteLine();
    }
    public double Perimeter()
    {
        // получение периметра
        return this.a + this.b + this.c;
    }
    public double Square() {
        // получение площади
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - this.a) * (p - this.b) * (p - this.c));
    }
    public static bool IsTriangle(double a, double b, double c) { 
        // проверка на треугольник
        if (a < b + c && b < a + c && c < a + b) { return true; }
        return false;
    }
}

class Program {    
    public static void Main(string[] args) {
        // разносторонний треугольник
        Triangle t1 = new Triangle(5, 7, 9);
        t1.Show();
        // равносторонний треугольник
        Triangle t2 = new Triangle(5, 5, 5);
        t2.Show();
        // не треугольник
        try
        {
            Triangle t3 = new Triangle(3, 5, 8);
            t3.Show();
        }
        catch (ArgumentException e) { 
            Console.WriteLine("Треугольник с указанными сторонами не существует");
        }
    }
}