using System;
using System.Text;

namespace Mediator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            PrinterMediator mediator = new PrinterMediator();

            PrinterSwitcher switcher = new PrinterSwitcher(mediator);
            PrinterPrinthead printhead = new PrinterPrinthead(mediator);
            PrinterPaintExtractor extractor = new PrinterPaintExtractor(mediator);

            mediator.switcher = switcher;
            mediator.printhead = printhead;
            mediator.extractor = extractor;

            Console.OutputEncoding = Encoding.UTF8;
            switcher.SendMessage("Запуск печатающей головки");
            printhead.SendMessage("Распылить краску на бумагу");
            extractor.SendMessage("Закончить распечатывать");
        }

    }
}
