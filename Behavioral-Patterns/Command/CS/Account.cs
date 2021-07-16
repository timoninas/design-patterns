using System;

namespace Command
{
    public class TransactionAccount
    {
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public TransactionAccount(string name, double balance) 
        {
            Name = name;
            Balance = balance;
        }

        public enum TypeTransaction
        {
            Deposit,
            Withdraw
        }

        public int PerformOperation(double count, TypeTransaction type)
        {
            if (type == TypeTransaction.Deposit)
            {
                Balance += count;
            }
            else if (type == TypeTransaction.Withdraw)
            {
                if (Balance >= count)
                {
                    Balance -= count;
                } else
                {
                    return -1;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            return $"Account: {Name}, Balance: {Balance}";
        }
    }
}
