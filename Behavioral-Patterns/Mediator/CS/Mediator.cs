using System;
namespace Mediator
{
    // MEDIATOR
    public interface IMediator
    {
        void sendMessage(string message, Printer part);
    }

    public class PrinterMediator: IMediator
    {
        public PrinterSwitcher switcher { get; set; }
        public PrinterPrinthead printhead { get; set; }
        public PrinterPaintExtractor extractor { get; set; }

        public void sendMessage(string message, Printer part)
        {
            if (switcher == part)
            {
                printhead.Notify(message);
            }
            else if (printhead == part)
            {
                extractor.Notify(message);
            }
            else if (extractor == part)
            {
                switcher.Notify(message);
            }
        }
    }

    public abstract class Printer
    {
        private IMediator mediator;

        public Printer(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void SendMessage(string message)
        {
            mediator.sendMessage(message, this);
        }

        public abstract void Notify(string message);
    }

    public class PrinterSwitcher: Printer
    {
        public PrinterSwitcher(IMediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine($"Switcher: {message}");
        }
    }

    public class PrinterPrinthead : Printer
    {
        public PrinterPrinthead(IMediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine($"Printhead: {message}");
        }
    }

    public class PrinterPaintExtractor : Printer
    {
        public PrinterPaintExtractor(IMediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine($"PaintExtractor: {message}");
        }
    }
}
