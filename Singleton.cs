using System;
using System.Collections.Generic;

namespace lab3
{
    [Serializable]
    public class Singleton
    {
        public List<object> ListOfObjects;
        private static Singleton instance;

        private Singleton()
        {
            ListOfObjects = new List<object>();
        }

        public static Singleton GetInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}
