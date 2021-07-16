using System;
namespace ChainOfResponsbility
{
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }

    public abstract class Handler
    {
        protected Handler _successor;

        public abstract void Handle(User user);

        public Handler()
        {
            _successor = null;
        }

        public Handler(Handler successor)
        {
            this._successor = successor;
        }

        public void SetSuccessor(Handler succ)
        {
            if (succ == null)
            {
                throw new NullReferenceException(nameof(succ));
            }

            _successor = succ;
        }
    }


    public class AdminChainAuth: Handler
    {
        public AdminChainAuth() : base() { }

        public AdminChainAuth(Handler successor) : base(successor) { }

        public override void Handle(User user)
        {
            if (user.Login.Contains("admin"))
            {
                Console.WriteLine("Administrator!");
            }
            else if (this._successor != null)
            {
                this._successor.Handle(user);
            }
        }
    }

    public class CustomerChainAuth : Handler
    {
        public CustomerChainAuth() : base() { }

        public CustomerChainAuth(Handler successor) : base(successor) { }

        public override void Handle(User user)
        {
            if (user.Login.Contains("user"))
            {
                Console.WriteLine("User!");
            }
            else if (this._successor != null)
            {
                this._successor.Handle(user);
            }
        }
    }

    public class DefaultChainAuth : Handler
    {
        public DefaultChainAuth() : base() { }

        public DefaultChainAuth(Handler successor) : base(successor) { }

        public override void Handle(User user)
        {
            Console.WriteLine("No name!");
        }
    }
}
