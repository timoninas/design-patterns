using System;

namespace Command
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TransactionAccount account = new TransactionAccount("Antont TImonin", 0);
            TransactionCenter center = new TransactionCenter();

            center.RegisterTransaction(new Withdraw(account, 10000));
            center.RegisterTransaction(new Deposit(account, 11000));

            center.ProcessingTransactions();
            Console.WriteLine(account.ToString());

            center.ProcessingTransactions();
            Console.WriteLine(account.ToString());
        }

        // OUTPUT
        // Account: Antont TImonin, Balance: 11000
        // Account: Antont TImonin, Balance: 1000
    }
}
