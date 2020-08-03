using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Adapter
{
    // ForeignMachineAdapter: ICashMachine
    public class ForeignMachineAdapter: ICashMachine
    {
        public string Number { get; private set; }

        private ForeignMachine _machine;

        public IReadOnlyList<Product> Products
        {
            get
            {
                var productsTuple = _machine.CurrentCheck.Products;
                var products = productsTuple.Select(foreignProduct => new Product(foreignProduct.Name, foreignProduct.Price));
                return (IReadOnlyList<Product>)products;
            }
        }

        public ForeignMachineAdapter(ForeignMachine machine)
        {
            this._machine = machine;
            this.Number = Guid.NewGuid().ToString();
        }

        public void AddProduct(Product product)
        {
            if (_machine == null)
            {
                throw new ArgumentNullException(nameof(_machine));
            }

            this._machine.Add(product.Name, product.Price);
        }

        public string PrintCheck()
        {
            string text = "";
            text += $"Номер кассового аппарата {this.Number}\n";
            text += $"{this._machine.CurrentCheck.ToString()}\n";
            text += $"Список товаров:\n";

            foreach (var product in _machine.CurrentCheck.Products)
            {
                text += $"{product.ToString()}\n";
            }

            text += $"Итоговая цена: {_machine.CurrentCheck.TotalPrice}";

            return text;
        }

        public void SaveCheckInFile(string check)
        {
            string filename = "check1.txt";

            using (var sw = new StreamWriter(filename, false, Encoding.Unicode))
            {
                sw.Write(check);
            }
        }
    }
}
