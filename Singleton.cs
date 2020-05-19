using System;
using System.Collections.Generic;

namespace lab3
{
    [Serializable]
    public class Singleton
    {
        List<object> ListOfObjects;

        public List<object> getInstance()
        {
            if (ListOfObjects == null)
                ListOfObjects = new List<object>();
            return ListOfObjects;
        }
    }
}
