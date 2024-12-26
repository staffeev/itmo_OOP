using System;


interface IPubs {
    // интерфейс подписки на издание
    void Subs()
    { // вывод информации о подписке
        Console.WriteLine("Подписка на издание: {0}.", (IfSubs) ? "да" : "нет");
    }
    bool IfSubs { get; set; }
}


abstract class Item : IComparable
{
    // класс библиотечной единицы хранения
    protected long invNumber;
    protected bool inLibrary;

    int IComparable.CompareTo(object obj)
    { // сравнение печатных изданий по инвентарному номеру
        Item it = (Item)obj;
        if (invNumber == it.invNumber) return 0;
        else if (invNumber > it.invNumber) return 1;
        return -1;
    }
    public Item(long invNumber, bool inLibrary)
    { // конструктор
        this.invNumber = invNumber;
        this.inLibrary = inLibrary;
    }
    public Item() { this.inLibrary = true; } // по умолчанию объект в библиотеке
    public bool IsAvailable() { return inLibrary; } // наличие
    public long GetInvNumber() { return invNumber; } //выдача ID
    private void Take() { inLibrary = false; } // взятие книги
    public void TakeItem()
    { // взятие книги при наличии
        if (this.IsAvailable()) this.Take();
    }
    abstract public void Return();
    public virtual void Show()
    {
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
        int year, long invNumber, bool inLibrary) : base(invNumber, inLibrary)
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

    public void ReturnOnTime()
    {
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
        base.Show();
        Console.WriteLine();
    }
}

class Magazine : Item, IPubs
{
    // поля
    private string volume;
    private int number;
    private string title;
    private int year;
    public bool IfSubs { get; set; }
    public void Subs()
    { // вывод информации о подписке
        Console.WriteLine("Подписка на журнал \"{0}\": {1}." , 
            title, (IfSubs)? "да" : "нет");
    }
public Magazine() { }
    public Magazine(string volume, int number, string title, int year,
        long invNumber, bool inLibrary) : base(invNumber, inLibrary)
    {
        // конструктор
        this.volume = volume;
        this.number = number;
        this.title = title;
        this.year = year;
    }
    override public void Show()
    { // вывод информации
        Console.WriteLine("Журнал:");
        Console.WriteLine("Том: {0}", volume);
        Console.WriteLine("Номер: {0}", number);
        Console.WriteLine("Название: {0}", title);
        Console.WriteLine("Год выпуска: {0}\n", year);
        base.Show();
        Console.WriteLine();
    }

    public override void Return()
    { // возврат журнала
        inLibrary = true;
    }
}


class Program
{
    public static void Main(string[] args)
    {
        Book b1 = new Book("Чак Паланик", "Снафф", "АСТ", 256, 2022, 13, true);
        Book b2 = new Book("Дж. Уиндем", "День триффидов", "АСТ", 320, 2022, 156, true);
        Book b3 = new Book("У. Берроуз", "Голый завтрак", "АСТ", 320, 2019, 1, true);
        Magazine mag = new Magazine("УДК 323 Внутренняя политика", 3, "ВЕСТНИК ОГУ", 2013, 100, true);
        Item[] items = { b1, b2, b3, mag };
        Array.Sort(items);
        foreach (Item item in items) { item.Show(); }
    }
}