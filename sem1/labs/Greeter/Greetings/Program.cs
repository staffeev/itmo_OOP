using System;

class Greeter
{
    static void Main(string[] args)
    {
        string myName;
        Console.WriteLine("Please enter your name");
        // получение и вывод имени
        myName = Console.ReadLine();
        Console.WriteLine("Hello, {0}", myName);
    }
}