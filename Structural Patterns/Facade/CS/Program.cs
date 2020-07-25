using System;

namespace Facade
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ISpellChecker SpellChecker = new SpellChecker();
            IAutharizateCheck AuthChecker = new Authorizator();

            BlogFacade facade = new BlogFacade(SpellChecker, AuthChecker);

            bool result1 = facade.PublishPost(new BlogPost("Title tmp", "Content tmp"), new User("Antont", "Timont"));
            bool result2 = facade.PublishPost(new BlogPost("Title", "Title"), new User("WoWoMan", "Man"));
            bool result3 = facade.PublishPost(new BlogPost("Title1", "Title2"), new User("Kjas", "Olkg"));
            bool result4 = facade.PublishPost(new BlogPost("Hello", "World!"), new User("Name", "Name"));

            Console.WriteLine($"Result of adding posts: \n{result1}\n{result2}\n{result3}\n{result4}\n");

            foreach (var item in facade.posts)
            {
                Console.WriteLine($"User: username - {item.Key.username}; password- {item.Key.password}");
                Console.WriteLine($"Post: title - {item.Value.title}; content- {item.Value.content}\n");
            }

            // Result of adding posts: 
            // True
            // False
            // True
            // False

            // User: username - Antont; password - Timont
            // Post: title - Title tmp; content - Content tmp

            // User: username - Kjas; password - Olkg
            // Post: title - Title1; content - Title2
        }
    }
}
