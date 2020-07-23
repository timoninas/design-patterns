using System;

namespace ProxyPattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            UserStorageProxy proxy = new UserStorageProxy();

            User user1 = proxy.GetConcreteUser(1);
            User user2 = proxy.GetConcreteUser(1);
            User user3 = proxy.GetConcreteUser(100);

            Console.WriteLine($"User1 - {user1.id} {user1.username} {user1.password}");
            Console.WriteLine($"User2 - {user2.id} {user2.username} {user2.password}");
            if (user3 == null)
            {
                Console.WriteLine($"User3 - null null null");
            } else
            {
                Console.WriteLine($"User3 - {user3.id} {user3.username} {user3.password}");
            }

            // OUTPUT
            // Accessing the ReceivedUsers
            // Accessing the UserContext
            // User1 - 1 login password
            // User2 - 1 login password
            // User3 - null null null
        }
    }
}
