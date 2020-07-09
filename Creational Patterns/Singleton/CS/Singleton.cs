using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    class Singleton
    {
        private static Singleton instance;
        public string namePattern { get; private set; }
        protected Singleton(string name) 
        {
            this.namePattern = name;
        }

        public static Singleton getInstance(string name)
        {
            if (instance == null)
            {
                instance = new Singleton(name);
            }

            return instance;
        }
    }
}
