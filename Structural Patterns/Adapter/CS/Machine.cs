using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adapter
{
    // Machine: ICashMachine
    // number
    // <product>
    // AddProduct()
    // PrintCheck()
    // SaveCheckInFile()

    // Product
    // Name
    // Price
    // ToString

    public interface ICashMachine
    {
        string Number { get; }

        IReadOnlyList<Product> Products { get; }

        void AddProduct(Product product);

        string PrintCheck();

        void SaveCheckInFile(string check);
    }

    public class Machine : ICashMachine
    {
        private Guid _number;

        private List<Product> _products;

        public string Number => _number.ToString();

        public IReadOnlyList<Product> Products => _products;


        public Machine()
        {
            this._number = Guid.NewGuid();
            this._products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (_products == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _products.Add(product);
        }

        public string PrintCheck()
        {
            string totalCheck = "";
            double totalSum = 0;

            totalCheck += $"Номер кассового аппарата {this.Number}\n";
            totalCheck += $"Список товаров:\n";
            foreach (var product in this.Products)
            {
                totalCheck += $"{product.ToString()}\n";
                totalSum += product.Price;
            }
            totalCheck += $"Итоговая цена: {totalSum} руб.\n";

            return totalCheck;
        }

        public void SaveCheckInFile(string check)
        {
            if (check == null || check == "") 
            {
                throw new ArgumentNullException(nameof(check));
            }

            using (var sw = new StreamWriter("checks.txt", false, Encoding.Unicode))
            {
                sw.Write(check);
            }

            _products.Clear();
        }
    }

    public struct Product
    {
        public string Name { get; private set; }

        public double Price { get; private set; }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price} руб.";
        }
    }
}
