using System;

namespace Iterator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var array = new ConcreteArray();
            var iterator = array.CreateIterator();

            for (int i = 0; i < 10; i++)
            {
                array[0] = i;
            }

            while (!iterator.IsDone())
            {
                Console.WriteLine($"{iterator.Next()}"); 
            }
        }
        
        // OUTPUT
        // 8
        // 7
        // 6
        // 5
        // 4
        // 3
        // 2
        // 1
        // 0
    }
}
