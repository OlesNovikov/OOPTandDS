using System.Collections.Generic;
using mySerialization;

namespace lab3
{
    public class SerializationStrategy
    {
        public SerializationStrategy(ISerialization serialization)
        {
            this.serialization = serialization;
        }

        ISerialization serialization;
        public string OnSave(List<object> listOfObjects, string fileName)
        {
            return serialization.OnSave(listOfObjects, fileName);
        }

        public List<object> OnLoad(string fileName)
        {
            return serialization.OnLoad(fileName);
        }
    }
}
