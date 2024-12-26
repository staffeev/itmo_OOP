using System;


class Book {
    // атрибуты
    private String author;
    private String title;
    private String publisher;
    private int pages;
    private int year;
    private static double price = 9; // стоимость аренды фиксированная
    public Book() {}
    public Book(String author, String title, String publisher, int pages, int year)
    { // установка атрибутов  
        this.author = author;
        this.title = title;
        this.publisher = publisher;
        this.pages = pages;
        this.year = year;
    }
    public Book(String author, String title)
    { // перегрузка конструктора
        this.author = author;
        this.title = title;
    }

    static Book()
    { // вызов до обращения к любому элементу класса
        price = 15;
    }
    public static void SetPrice(double price)
    { // установка стоимости аренды
        Book.price = price;
    }
    public double PriceBook(int s)
    { // стоимость аренды на s суток
        return s * price;
    }
    public void Show()
    { // вывод информации о книге
        Console.WriteLine("Книга:");
        Console.WriteLine("Название: {0}", title);
        Console.WriteLine("Автор: {0}", author);
        Console.WriteLine("Год издания: {0}", year);
        Console.WriteLine("Количество страниц: {0}", pages);
        Console.WriteLine("Стоимость аренды: {0}", Book.price);
    }
}


class Program {
    public static void Main(string[] args) {
        Book b = new Book("Чак Паланик", "Снафф");
        b.Show();
    }
}