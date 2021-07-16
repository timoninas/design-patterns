using System;

namespace Memento
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            HistoryDrawing history = new HistoryDrawing();
            Drawing drawing1 = new Drawing();

            drawing1.Add(new Point(3, 4));
            drawing1.Add(new Point(-1, 2));
            drawing1.Add(new Point(10, 6));

            Drawing drawing2 = new Drawing();

            drawing2.Add(new Point(0, 1));
            drawing2.Add(new Point(1, 0));
            drawing2.Add(new Point(2, 1));

            history.Push(drawing1.SaveState());
            history.Push(drawing2.SaveState());

            Console.WriteLine(history.Pop().ToString());
            Console.WriteLine(history.Pop().ToString());

            // OUTPUT
            // MementoDrawing
            // Point(0, 1)
            // Point(1, 0)
            // Point(2, 1)

            // MementoDrawing
            // Point(3, 4)
            // Point(-1, 2)
            // Point(10, 6)
        }
    }
}
