using System;
using System.Collections.Generic;

namespace Bridge
{
    public class Bridge
    {
        public class Item
        {
            public int id { get; private set; }
            public double price { get; private set; }
            public double weight { get; private set; }

            public Item(int id, double price, double weight)
            {
                this.id = id;
                this.price = price;
                this.weight = weight;
            }
        }

        // ABSTRACTION
        public abstract class PriceCalculator
        {
            protected IPriceItemCalculator_Realisation _impl { get; set; }
            public List<Item> Items { get; private set; }

            public PriceCalculator(IPriceItemCalculator_Realisation implementation)
            {
                this._impl = implementation;
                this.Items = new List<Item>();
            }

            public void Add(Item item)
            {
                this.Items.Add(item);
            }

            public abstract double GetTotalPrice();
        }

        // CONCRETE ABSTRACTION
        public class ConcretePriceCalculator: PriceCalculator
        {
            public ConcretePriceCalculator(IPriceItemCalculator_Realisation implementation):
                base(implementation) { }

            public override double GetTotalPrice()
            {
                double totalPrice = 0;

                if (this.Items.Count > 0)
                {
                    foreach (Item item in this.Items)
                    {
                        totalPrice += this._impl.GetItemPrice(item);
                    }
                }

                return totalPrice;
            }
        }




        //REALIZATION
        public interface IPriceItemCalculator_Realisation
        {
            double GetItemPrice(Item item);
        }

        // CONCRETE REALIZATION 1
        public class CounterByPrice: IPriceItemCalculator_Realisation
        {
            public double GetItemPrice(Item item)
            {
                double totalPrice = item.price;

                return totalPrice;
            }
        }

        // CONCRETE REALIZATION 2
        public class CounterByPriceAndWeight : IPriceItemCalculator_Realisation
        {
            public double GetItemPrice(Item item)
            {
                double totalPrice = item.price + item.weight * 0.1;

                return totalPrice;
            }
        }
    }
}
