using System;
using System.Collections.Generic;

namespace Observer
{
    // СМОТРЯЩИЙ
    public interface IObserver
    {
        void Update();
    }

    // ОБОЗРИМЫЙ
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class NotificationCenter: IObservable
    {
        public List<IObserver> Observers { get; private set; }

        public NotificationCenter()
        {
            Observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            if (observer == null)
            {
                throw new NullReferenceException(nameof(observer));
            }

            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observer == null)
            {
                throw new NullReferenceException(nameof(observer));
            }

            Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach(IObserver observer in Observers)
            {
                observer.Update();
            }
        }
    }

    class Card: IObserver
    {
        public int Number { get; private set; }
        public bool IsSwiped { get; private set; }

        public Card(int number)
        {
            Number = number;
            IsSwiped = false;
        }

        public void Swipe(int swipeDirection)
        {
            if (swipeDirection >= 0)
            {
                IsSwiped = true;
            }
        }

        public void Update()
        {
            if (IsSwiped == true)
            {
                Console.WriteLine($"Card#{Number} has swiped!");
            }
            else
            {
                Console.WriteLine($"Card#{Number} hasn't swiped!");
            }
        }
    }
}
