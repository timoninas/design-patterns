using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(10);
            Circle circle2;

            circle2 = (Circle)circle1.clone();

            circle1.GetInfo();
            circle2.GetInfo();


            Rectangle rectangle1 = new Rectangle(10, 3);
            Rectangle rectangle2;

            rectangle2= (Rectangle)rectangle1.clone();

            rectangle1.GetInfo();
            rectangle2.GetInfo();

            /* OUTPUT
             * Shape of this Circle: 10
             * Shape of this Circle: 10
             * Shape of this Rectangle: 2x3
             * Shape of this Rectangle: 2x3
             */
        }
    }
}
