using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton tmp1;
            Singleton tmp2;

            tmp1 = Singleton.getInstance("Singleton pattern");
            tmp2 = Singleton.getInstance("NOT Singleton pattern");

            Console.WriteLine(tmp1.namePattern);
            Console.WriteLine(tmp2.namePattern);
        }
    }
}
