using System;

namespace Adapter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region Machine
            ICashMachine machine = new Machine();

            machine.AddProduct(new Product("Арбуз", 220));
            machine.AddProduct(new Product("Креветки", 590.10));
            machine.AddProduct(new Product("Квас", 59.90));

            string check = machine.PrintCheck();

            Console.Write(check);

            machine.SaveCheckInFile(check);

            // FILE CONTENT
            // Номер кассового аппарата 925a322c - 4ca4 - 4e13 - b817 - 23e5b1091298
            // Список товаров:
            // Арбуз - 220 руб.
            // Креветки - 590,1 руб.
            // Квас - 59,9 руб.
            // Итоговая цена: 870 руб.
            #endregion



            #region AdapteeMachine
            ForeignMachine machine1 = new ForeignMachine("IEE-083 3220");
            ForeignMachineAdapter adapter = new ForeignMachineAdapter(machine1);

            machine1.Add("Арбуз", 220);
            machine1.Add("Креветки", 590.10);
            machine1.Add("Квас", 59.90);

            string check1 = adapter.PrintCheck();

            Console.Write(check);

            adapter.SaveCheckInFile(check);

            // FILE CONTENT
            // Номер кассового аппарата e6799119-5777 - 4505 - 9667 - 0fe9e794883a
            // Кассовый чек от 12: 10 03.августа.2020
            // Номер чека: 46736
            // Список товаров:
            // Арбуз - 220 руб.
            // Креветки - 590,1 руб.
            // Квас - 59,9 руб.
            // Итоговая цена: 870
            #endregion
        }
    }
}
