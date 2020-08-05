using System;

namespace Decorator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IComputer computer = new Computer("Igronator");
            IComputer computerO = new OperativeMemoryDecorator(computer);
            IComputer computerVV = new VideocardDecorator(new VideocardDecorator(computer));
            IComputer computerOVV = new VideocardDecorator(new VideocardDecorator(computerO));

            Console.WriteLine($"{computer.GetInfo()} - {computer.GetPrice()}");
            Console.WriteLine($"{computerO.GetInfo()} - {computerO.GetPrice()}");
            Console.WriteLine($"{computerVV.GetInfo()} - {computerVV.GetPrice()}");
            Console.WriteLine($"{computerOVV.GetInfo()} - {computerOVV.GetPrice()}");

            // OUTPUT
            // Igronator - 500
            // Igronator 8 gb - 600
            // Igronator Videocard GTX Videocard GTX - 1000
            // Igronator 8 gb Videocard GTX Videocard GTX - 1100
        }
    }
}
