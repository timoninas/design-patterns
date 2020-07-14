using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ObjectPool
{
    /*
     * Интерфейс для обьектов пула, которые 
     * при завершении работы могут быть 
     * возвращены в исходное состояние для
     * переиспользования
     */
    public interface IPoolable
    {
        void ResetState();
    }

    /*
     * Интерфейс для создания обьектов
     */
    public interface IPoolObjectCreator<T>
    {
        T Create();
    }

    /*
     * Класс для создания екземпляров с
     * помощью конструктора без параметров
     */
    public class DefaultObjectCreator<T>: IPoolObjectCreator<T> where T: class, new()
    {
        T IPoolObjectCreator<T>.Create() {
            return new T();
        }
    }

    public class ObjectPool<T> where T : class, IPoolable
    {
        private readonly ConcurrentBag<T> _container = new ConcurrentBag<T>();
        private readonly IPoolObjectCreator<T> _objectCreator;

        public int Count { get { return _container.Count; } }

        public ObjectPool(IPoolObjectCreator<T> creator)
        {
            if (creator == null) {
                throw new ArgumentNullException("Creator == null");
            }

            this._objectCreator = creator;
        }

        public T GetObject()
        {
            T obj;
            // TryTake - пытается удалить и вернуть объект из коллекции
            if (this._container.TryTake(out obj)) {
                return obj;
            }

            return this._objectCreator.Create();
        }

        public void ReturnObject(ref T obj)
        {
            obj.ResetState();
            this._container.Add(obj);
            obj = null;
        }
    }

    public class SomeObject : IPoolable
    {
        private int _id { get; set; }

        public int Index { get; set; }

        public SomeObject()
        {
            var random = new Random();
            this._id = random.Next(0, 1000);
            Console.WriteLine("SomeObject#" + this._id.ToString() + " constructor");
            this.Index = -1;
        }

        void IPoolable.ResetState()
        {
            Console.WriteLine("SomeObject#" + this._id.ToString() + " reset state");
            this.Index = -1;
        }
    }
}
