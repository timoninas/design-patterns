using System;

namespace Observer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();
            NotificationCenter center = new NotificationCenter();

            for (int i = 0; i < 10; i++)
            {
                var card = new Card(i);
                if (i > 2 && i % 2 == 0)
                {
                    card.Swipe(-3 + i);
                }
                center.AddObserver(card);
            }

            center.NotifyObservers();
        }

        // OUTPUT
        // Card#0 hasn't swiped!
        // Card#1 hasn't swiped!
        // Card#2 hasn't swiped!
        // Card#3 hasn't swiped!
        // Card#4 has swiped!
        // Card#5 hasn't swiped!
        // Card#6 has swiped!
        // Card#7 hasn't swiped!
        // Card#8 has swiped!
        // Card#9 hasn't swiped!
    }
}
