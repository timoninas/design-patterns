using System;
using System.Collections.Generic;

namespace Memento
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }

    // OBJECT DRAING
    public class Drawing
    {
        public List<Point> points { get; private set; }

        public Drawing()
        {
            this.points = new List<Point>(); 
        }

        public void Add(Point point)
        {
            this.points.Add(point);
        }

        public MementoDrawing SaveState()
        {
            return new MementoDrawing(this);
        }

        public void RestoreState(MementoDrawing newState) {
            this.points.Clear();

            foreach (Point point in newState.Points)
            {
                points.Add(point);
            }
        }
    }

    // MEMENTO
    public class MementoDrawing
    {
        public List<Point> Points { get; private set; }

        public MementoDrawing(Drawing drawing)
        {
            this.Points = new List<Point>();

            foreach (Point point in drawing.points)
            {
                Points.Add(point);
            } 
        }

        public override string ToString()
        {
            string text = "MementoDrawing\n";
            foreach(var item in this.Points)
            {
                text += $"{item.ToString()}\n";
            }
            text += "\n";

            return text;
        }
    }

    // CARETAKER
    public class HistoryDrawing
    {
        public Stack<MementoDrawing> Drawings { get; private set; }

        public HistoryDrawing()
        {
            this.Drawings = new Stack<MementoDrawing>();
        }

        public void Push(MementoDrawing drawing)
        {
            this.Drawings.Push(drawing);
        }

        public MementoDrawing Pop()
        {
            return this.Drawings.Pop();
        }
    }
}
