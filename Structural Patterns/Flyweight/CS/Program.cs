using System;

namespace Flyweight
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IFlyweightFactory factory = new FlyweightFactory();

            var a = factory.GetFlyweight('a');
            Console.WriteLine($"{a.id}");

            var b = factory.GetFlyweight('b');
            Console.WriteLine($"{b.id}");

            var c = factory.GetFlyweight('b');
            Console.WriteLine($"{c.id}");

            var d = factory.GetFlyweight('d');
            Console.WriteLine($"{d.id}");

            // 594
            // 899
            // 899
            // 401
        }
    }
}
