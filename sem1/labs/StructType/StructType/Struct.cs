using System;

public enum AccountType {Checking, Deposit}

public struct BankAccount {
    public long accNo;
    public decimal accBal;
    public AccountType accType;

}

class Program {
    static void Main(string[] args) {
        // создание банковского аккаунта
        try
        {
            BankAccount goldAccount;
            Console.WriteLine("Enter account number:");
            goldAccount.accNo = long.Parse(Console.ReadLine());
            goldAccount.accType = AccountType.Checking;
            Console.WriteLine("Enter account balance:");
            goldAccount.accBal = decimal.Parse(Console.ReadLine());
            // вывод данных аккаунта
            Console.WriteLine("*** Account Summary ***");
            Console.WriteLine("Account number - {0}\nAccount type - {1}\nAccount balance - {2}",
                goldAccount.accNo, goldAccount.accType, goldAccount.accBal);
        }
        catch (FormatException e) {
            Console.WriteLine("A format exception has occuried: {0}", e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An unexpected error has occuried: {0}", e.Message);
        }
    }
}