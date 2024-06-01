using Mybank;
using System;

namespace Bankapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Bankacct("Ram", 10000);
            Console.WriteLine($"Account number is {account.Number} and account name is {account.Owner} and balance is {account.Balance}");
            account.Makewithdraw(120, DateTime.Now, "Soap");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.Getapptrans());

            

        }
    }
}