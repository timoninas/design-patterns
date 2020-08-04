using System;
using System.Collections.Generic;

namespace Flyweight
{
    public interface IFlyweightFactory
    {
        Flyweight GetFlyweight(char symbol);
    }

    public class FlyweightFactory: IFlyweightFactory
    {
        private Dictionary<char, Flyweight> alphabet;

        public FlyweightFactory()
        {
            alphabet = new Dictionary<char, Flyweight>();
        }

        public Flyweight GetFlyweight(char symbol)
        {
            if (!this.alphabet.ContainsKey(symbol))
            {
                this.alphabet.Add(symbol, new WordFlyweight());
            }

            return this.alphabet[symbol] as Flyweight;
        }
    }

    public abstract class Flyweight
    {
        protected static int CountUsedWords = 0;

        public int id { get; private set; }

        public Flyweight()
        {
            CountUsedWords++;
            var random = new Random();
            this.id = random.Next(0, 1000);
        }

        public abstract void SomeOperation(string message);
    }

    public class WordFlyweight: Flyweight
    {
        public WordFlyweight(): base() { }

        public override void SomeOperation(string message)
        {
            Console.WriteLine($"Message: {message}\n Count used words: {Flyweight.CountUsedWords}");
        }
    }
}
