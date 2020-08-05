using System;
namespace Decorator
{
    public interface IComputer
    {
        string GetInfo();

        double GetPrice();
    }

    public class Computer: IComputer
    {
        public string name { get; private set; }

        public Computer(string name)
        {
            this.name = name;
        }

        public string GetInfo()
        {
            return name;
        }

        public double GetPrice()
        {
            return 500;
        }
    }

    public abstract class ComputerDecorator: IComputer
    {
        protected IComputer computer;

        public ComputerDecorator(IComputer computer)
        {
            this.computer = computer;
        }

        public abstract string GetInfo();

        public abstract double GetPrice();
    }

    public class OperativeMemoryDecorator: ComputerDecorator
    {
        public OperativeMemoryDecorator(IComputer computer) : base(computer) { }

        public override string GetInfo()
        {
            return computer.GetInfo() + " 8 gb";
        }

        public override double GetPrice()
        {
            return computer.GetPrice() + 100;
        }
    }

    public class VideocardDecorator : ComputerDecorator
    {
        public VideocardDecorator(IComputer computer) : base(computer) { }

        public override string GetInfo()
        {
            return computer.GetInfo() + "  Videocard GTX";
        }

        public override double GetPrice()
        {
            return computer.GetPrice() + 250;
        }
    }
}
