using System;


abstract class Item {
    // класс библиотечной единицы хранения
    protected long invNumber;
    protected bool inLibrary;
    public Item(long invNumber, bool inLibrary)
    { // конструктор
        this.invNumber = invNumber;
        this.inLibrary = inLibrary;
    }
    public Item() { this.inLibrary = true; } // по умолчанию объект в библиотеке
    public bool IsAvailable() { return inLibrary; } // наличие
    public long GetInvNumber() { return invNumber; } //выдача ID
    private void Take() { inLibrary = false; } // взятие книги
    public void TakeItem() { // взятие книги при наличии
        if (this.IsAvailable()) this.Take();
    }
    abstract public void Return();
    public virtual void Show() {
        Console.WriteLine("Информация о единице хранения:");
        Console.WriteLine("Инвентарный номер: {0}", invNumber);
        Console.WriteLine("В наличии: {0}", (this.IsAvailable()) ? "да" : "нет");
    }

}


class Book : Item
{
    // атрибуты
    private String author;
    private String title;
    private String publisher;
    private int pages;
    private int year;
    private bool returnedOnTime;
    private static double price = 9; // стоимость аренды фиксированная
    public Book() { }
    public Book(String author, String title, String publisher, int pages, 
        int year, long invNumber, bool inLibrary) : base (invNumber, inLibrary)
    { // конструктор
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

    public void ReturnOnTime() { 
        // указание на возврат в срок
        returnedOnTime = true;

    }
    public override void Return()
    { // возврат книги (должна быть в срок)
        if (returnedOnTime) inLibrary = true;
    }
    public static void SetPrice(double price)
    { // установка стоимости аренды
        Book.price = price;
    }
    public double PriceBook(int s)
    { // стоимость аренды на s суток
        return s * price;
    }
    override public void Show()
    { // вывод информации о книге
        Console.WriteLine("Книга:");
        Console.WriteLine("Название: {0}", title);
        Console.WriteLine("Автор: {0}", author);
        Console.WriteLine("Год издания: {0}", year);
        Console.WriteLine("Количество страниц: {0}", pages);
        Console.WriteLine("Стоимость аренды: {0} р. в сутки", Book.price);
        Console.WriteLine();
        base.Show();
    }
}

class Magazine : Item {
    // поля
    private string volume;
    private int number;
    private string title;
    private int year;
    public Magazine() { }
    public Magazine(string volume, int number, string title, int year,
        long invNumber, bool inLibrary) : base(invNumber, inLibrary) {
        // конструктор
        this.volume = volume;
        this.number = number;
        this.title = title;
        this.year = year;
    }
    override public void Show() { // вывод информации
        Console.WriteLine("Журнал:");
        Console.WriteLine("Том: {0}", volume);
        Console.WriteLine("Номер: {0}", number);
        Console.WriteLine("Название: {0}", title);
        Console.WriteLine("Год выпуска: {0}\n", year);
        base.Show();
    }

    public override void Return()
    { // возврат журнала
        inLibrary = true;
    }
}


class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Тестирование абстрактного класса\n");
        Item it;
        Book b = new Book("Чак Паланик", "Снафф", "АСТ", 256, 2022, 13, true);
        Magazine mag = new Magazine("УДК 323 Внутренняя политика", 3, "ВЕСТНИК ОГУ", 2013, 100, true);
        it = b;
        it.TakeItem();
        it.Return();
        it.Show();
        Console.WriteLine();

        it = mag;
        it.Return();
        it.TakeItem();
        it.Show();
    }
}