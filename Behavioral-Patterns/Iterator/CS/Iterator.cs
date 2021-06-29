using System;
using System.Collections.Generic;

namespace Iterator
{
    public abstract class Array
    {
        public abstract object this[int index] { get; set; }
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set; }
    }

    public class ConcreteArray: Array
    {
        private readonly List<int> _arraylist = new List<int>();
        
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _arraylist.Count; }

            protected set { }
        }

        public override object this[int index]
        {
            get { return this._arraylist[index]; }
            set
            {
                this._arraylist.Insert(index, (int)value);
            }
        }
    }

    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    public class ConcreteIterator: Iterator
    {
        private Array _array;
        private int _current;

        public ConcreteIterator(Array array)
        {
            this._array = array;
            this._current = 0;
        }

        public override object First()
        {
            if (_array.Count > 0)
            {
                return (int)_array[0];
            }

            return null;
        }

        public override object Next()
        {
            _current++;

            if (_current < _array.Count)
            {
                return (int)_array[_current];
            }

            return null;
        }

        public override bool IsDone()
        {
            return _current >= _array.Count;
        }

        public override object CurrentItem()
        {
            return (int)_array[_current];
        }
    }
}
