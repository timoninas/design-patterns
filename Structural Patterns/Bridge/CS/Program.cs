using System;
using static Bridge.Bridge;

namespace Bridge
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CounterByPrice counterbyprice = new CounterByPrice();
            CounterByPriceAndWeight counterbyweight = new CounterByPriceAndWeight();

            ConcretePriceCalculator calculator1 = new ConcretePriceCalculator(counterbyprice);
            ConcretePriceCalculator calculator2 = new ConcretePriceCalculator(counterbyweight);

            calculator1.Add(new Item(0, 20, 30));
            calculator1.Add(new Item(1, 50, 50));
            calculator1.Add(new Item(2, 90, 20));

            calculator2.Add(new Item(0, 20, 30));
            calculator2.Add(new Item(1, 50, 50));
            calculator2.Add(new Item(2, 90, 20));

            Console.WriteLine($"calculator1 - {calculator1.GetTotalPrice()}");
            Console.WriteLine($"calculator2 - {calculator2.GetTotalPrice()}");


            // OUTPUT
            // calculator1 - 160
            // calculator2 - 170
        }
    }
}
