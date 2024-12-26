using System;
public enum AccountType {Checking, Deposit}

class Program {
    static void Main(string[] args) { 
        AccountType goldAccount = AccountType.Checking;
        AccountType platinumAccount = AccountType.Deposit;
        Console.WriteLine("The Customer Account Type is {0}", goldAccount);
        Console.WriteLine("The Customer Account Type is {0}", platinumAccount);
    }

}