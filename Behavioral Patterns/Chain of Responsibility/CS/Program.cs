using System;

namespace ChainOfResponsbility
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AdminChainAuth admin = new AdminChainAuth();
            CustomerChainAuth customer = new CustomerChainAuth();
            DefaultChainAuth rascal = new DefaultChainAuth();

            admin.SetSuccessor(customer);
            customer.SetSuccessor(rascal);

            admin.Handle(new User("user", "userpass"));
            admin.Handle(new User("what", "is"));
            admin.Handle(new User("admin", "adminovich"));

            // OUTPUT
            // User!
            // No name!
            // Administrator!
        }
    }
}
