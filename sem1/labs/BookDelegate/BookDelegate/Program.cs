abstract class Item
{
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


class Operation {
    // класс-прослойка
    public static void ShowBook(Book b) {
        if (b.ReturnedOnTime) b.Show();
    }

    public static void ProcessBook(Book b) {
        Console.WriteLine("Книга {0} сдана в срок", b);
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
    private static double price = 9; // стоимость аренды фиксированная
    private bool returnedOnTime;
    public bool ReturnedOnTime {
        get { return returnedOnTime; }
        set { returnedOnTime = value; if (ReturnedOnTime) ReturnOnTimeEvent(this); }
    }
    public delegate void BookDelegate(Book b);
    public static event BookDelegate ReturnOnTimeEvent;
    public override string ToString()
    {
        return title + ", " + author + " Инв. номер " + invNumber;
    }

    public override void Return()
    { // возврат книги (должна быть в срок)
        if (returnedOnTime) inLibrary = true;
    }
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
class Program
{
    public static void Main(string[] args)
    {
        Book.ReturnOnTimeEvent += Operation.ProcessBook;
        Book b1 = new Book("С. Кинг", "Кристина", "АСТ", 544, 2022, 18, true);
        Book b2 = new Book("Ф. Кафка", "Лабиринт", "Азбука", 224, 2022, 160, true);
        Console.WriteLine("Проверка сданных книг 1");
        b1.ReturnedOnTime = true;
        Console.WriteLine("Проверка сданных книг 2");
        b2.ReturnedOnTime = true;
    }
}