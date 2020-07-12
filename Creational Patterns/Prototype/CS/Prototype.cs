using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    interface IFigure
    {
        public IFigure clone();
        public double GetShapeArea();
        public void GetInfo();
    }
    
    class Circle : IFigure
    {
        private uint _radiusCircle;
        
        public Circle(uint radius)
        {
            this._radiusCircle = radius;
        }
        
        public IFigure clone()
        {
            return new Circle(this._radiusCircle);
        }

        public double GetShapeArea()
        {
            return 3.14 * this._radiusCircle * this._radiusCircle;
        }

        public void GetInfo()
        {
            Console.WriteLine("Shape of this Circle: " +  this._radiusCircle.ToString());
        }
    }

    class Rectangle: IFigure
    {
        private uint _w, _h;

        public Rectangle(uint w, uint h)
        {
            this._w = 2;
            this._h = h;
        }

        public IFigure clone()
        {
            return new Rectangle(this._w, this._h);
        }

        public double GetShapeArea()
        {
            return this._w * this._h;
        }
        
        public void GetInfo()
        {
            Console.WriteLine("Shape of this Rectangle: " + this._w + "x" + this._h);
        }
    }
}
