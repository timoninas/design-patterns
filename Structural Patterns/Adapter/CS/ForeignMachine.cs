using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter
{
    // ForeignMachine
    // List<Check>
    // Name
    // Array<Check>
    // Add()
    // Save()
    // ToString

    // ForeignProduct
    // Name
    // Price
    // ToString

    // Check: IClonable
    // List<ForeignProducts>
    // Number
    // DateTime
    // List<ForeignProduct>
    // Add()
    // Clone
    // ToString

    public class ForeignMachine
    {
        public string Name { get; private set; }

        public List<Check> checks { get; private set; }

        public Check[] ArrayChecks => checks.ToArray();

        public Check CurrentCheck => checks.LastOrDefault();

        public ForeignMachine(string name)
        {
            this.Name = name;
            this.checks = new List<Check>();
            this.checks.Add(new Check());
        }

        public void Add(string name, double price)
        {
            if (this.checks == null)
            {
                throw new ArgumentNullException(nameof(this.checks));
            }

            if (price < 0)
            {
                throw new ArgumentException(nameof(price));
            }

            this.CurrentCheck.Add(name, price);
        }

        public Check Save()
        {
            Check check = (Check)CurrentCheck.Clone();
            this.checks.Add(new Check());
            return check;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public struct ForeignProduct
    {
        public string Name { get; private set; }

        public double Price { get; private set; }

        public ForeignProduct(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price} руб.";
        }
    }

    public class Check : ICloneable
    {
        private List<ForeignProduct> _products;

        public IReadOnlyList<ForeignProduct> Products => _products;

        public int Number { get; private set; }

        public DateTime date { get; private set; }

        public  Double TotalPrice
        {
            get
            {
                double totalPrice = 0;
                foreach (var product in this._products)
                {
                    totalPrice += product.Price;
                }

                return totalPrice;
            }
        }

        public Check()
        {
            var generator = new Random();
            int number = generator.Next(0, 100000);

            this.Number = number;
            this._products = new List<ForeignProduct>();
            this.date = DateTime.Now;
        }

        public void Add(string name, double price)
        {
            if (this._products == null)
            {
                throw new ArgumentNullException(nameof(this._products));
            }

            var product = new ForeignProduct(name, price);

            this._products.Add(product);
        }

        public object Clone()
        {
            return new Check
            {
                _products = this._products,
                Number = this.Number,
                date = this.date
            };
        }

        public override string ToString()
        {
            return $"Кассовый чек от {this.date.ToString("HH: mm dd.MMMM.yyyy")}\nНомер чека: {this.Number}";
        }
    }
}
