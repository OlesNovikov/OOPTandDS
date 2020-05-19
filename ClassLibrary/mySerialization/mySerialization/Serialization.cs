using System.Collections.Generic;

namespace lab3
{
    public abstract class Serialization
    {
        public abstract string OnSave(List<object> listOfObjects, string fileName);
        public abstract List<object> OnLoad(string fileName);
    }
}
