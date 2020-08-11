using System;
using System.Collections.Generic;

namespace Command
{
    // COMMAND
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public abstract class AnyCommand: ICommand
    {
        protected TransactionAccount _account;
        protected double _count;
        protected bool _isCompleted;

        public AnyCommand(TransactionAccount account, double count)
        {
            if (account == null)
            {
                throw new NullReferenceException(nameof(account));
            }

            if (count < 0)
            {
                _count = 0;
            }

            _account = account;
            _count = count;
            _isCompleted = false;
        }

        public abstract void Execute();
        public abstract void Undo();
    }

    // CONCRETE COMMAND
    public class Deposit : AnyCommand
    {
        public Deposit(TransactionAccount account, double count) : base(account, count) { }

        public override void Execute()
        {
            if (_isCompleted == false)
            {
                _account.PerformOperation(_count, TransactionAccount.TypeTransaction.Deposit);
                _isCompleted = true;
            }
        }

        public override void Undo()
        {
            if (_isCompleted == true)
            {
                if (_account.PerformOperation(_count, TransactionAccount.TypeTransaction.Withdraw) == 0) {
                    _isCompleted = false;
                }
            }
        }
    }

    // CONCRETE COMMAND
    public class Withdraw : AnyCommand
    {
        public Withdraw(TransactionAccount account, double count) : base(account, count) { }

        public override void Execute()
        {
            if (_isCompleted == false)
            {
                if (_account.PerformOperation(_count, TransactionAccount.TypeTransaction.Withdraw) == 0)
                {
                    _isCompleted = true;
                }
            }
        }

        public override void Undo()
        {
            if (_isCompleted == true)
            {
                _account.PerformOperation(_count, TransactionAccount.TypeTransaction.Deposit);
                _isCompleted = false;
            }
        }
    }    
}
