using System;
using System.Transactions;

class Point {
    // класс точки
    private double x, y;
    public Point() { }
    public Point(double x, double y) {
        // конструктор
        this.x = x; this.y = y;
    }
    public void Show() {
        // вывод информации
        Console.WriteLine("Точка с координтами ({0}, {1})", x, y);
    }
    public double GetDistance(Point p) {
        // расстояние между двумя точками
        return Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
    }
    public override string ToString()
    { // приведение к строке
        return "(" + x + "; " + y + ")";
    }
}

class Line {
    // класс линии
    private Point pStart, pEnd;
    public Line() { }
    public Line(Point pStart, Point pEnd) {
        this.pStart = pStart; this.pEnd = pEnd;
    }
    public void Show() {
        // вывод информации
        Console.WriteLine("Отрезок с координатами {0} - {1}", pStart, pEnd);
    }
    public double GetLength() { 
        // получение длины
        return pStart.GetDistance(pEnd);
    }
}

class Program {
    public static void Main(string[] args) {
        Point p1 = new Point();
        p1.Show();
        Point p2 = new Point(20, 21);
        p2.Show();
        Line line = new Line(p1, p2);
        line.Show();
        Console.WriteLine("Длина отрезка равна {0}", line.GetLength());
    }
}