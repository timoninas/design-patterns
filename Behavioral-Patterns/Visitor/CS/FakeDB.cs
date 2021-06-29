using System;
using System.Collections.Generic;

namespace Visitor
{
    public class FakeDB
    {
        public List<IAccount> db { get; private set; }

        public FakeDB()
        {
            db = new List<IAccount>();
        }

        public void Add(IAccount obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            db.Add(obj);
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < db.Count)
            {
                db.RemoveAt(index);
            }
        }

        public void ShowFormateInfo(IVisitor visitor)
        {
            foreach (var obj in db)
            {
                obj.Accept(visitor);
            }
        }
    }
}
