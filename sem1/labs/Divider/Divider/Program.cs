using System;

class DivideIt {
    static void Main(string[] args) {
        try
        {
            Console.WriteLine("Please enter the first integer");
            int num1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second integer");
            int num2 = Int32.Parse(Console.ReadLine());
            int res = num1 / num2;
            Console.WriteLine("The result of dividing {0} by {1} is {2}", num1, num2, res);
        }
        catch (FormatException e)
        {
            Console.WriteLine("A format exception was thrown: {0}", e.Message);
        }
        catch (DivideByZeroException e) {
            Console.WriteLine("A value exception was thrown: {0}", e.Message);
        }
        catch (Exception e) {
            Console.WriteLine("An exception was thrown: {0}", e.Message);
        }

    }
}