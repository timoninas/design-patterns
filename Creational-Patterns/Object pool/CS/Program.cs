using System;

namespace ObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            var pool = new ObjectPool<SomeObject>(new DefaultObjectCreator<SomeObject>());

            Console.WriteLine("[1] Use new keyword");
            for (int i = 0; i < 5; i++)
            {
                SomeObject obj = new SomeObject();
                obj.Index = 1;
            }

            Console.WriteLine("\n\n[2] Use object pool");
            for (int i = 0; i < 5; i++)
            {
                SomeObject obj = pool.GetObject();
                obj.Index = 1;
                pool.ReturnObject(ref obj);
            }

            /*
            OUTPUT
            [1] Use new keyword
            SomeObject#976 constructor
            SomeObject#397 constructor
            SomeObject#681 constructor
            SomeObject#168 constructor
            SomeObject#828 constructor


            [2] Use object pool
            SomeObject#514 constructor
            SomeObject#514 reset state
            SomeObject#514 reset state
            SomeObject#514 reset state
            SomeObject#514 reset state
            SomeObject#514 reset state
            */
        }
    }
}
