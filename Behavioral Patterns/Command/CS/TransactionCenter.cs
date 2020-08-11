using System;
using System.Collections.Generic;

namespace Command
{
    public class TransactionCenter
    {
        private List<ICommand> _operations;

        public TransactionCenter()
        {
            _operations = new List<ICommand>();
        }

        public void RegisterTransaction(ICommand transaction)
        {
            if (transaction == null)
            {
                throw new NullReferenceException(nameof(transaction));
            }

            _operations.Add(transaction);
        }

        public void ProcessingTransactions()
        {
            foreach (var trans in _operations)
            {
                trans.Execute();
            }
        }
    }
}
