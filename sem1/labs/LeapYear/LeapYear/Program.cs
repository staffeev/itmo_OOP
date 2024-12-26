using System;

class Program {
    static void Main(string[] args) {
        try
        {
            Console.WriteLine("Enter the year number:");
            ulong year = ulong.Parse(Console.ReadLine());
            if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0)) {
                Console.WriteLine("YES");
            } else {
                Console.WriteLine("NO");
            }
        }
        catch (FormatException e) { // если данные в неправильном формате
            Console.WriteLine("Format error:", e.Message);
        }
    }
}