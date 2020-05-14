using classesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mySerialization
{
    public interface ISerialization
    {
        string SerializeObjects(List<object> listOfObjects, string fileName);
        List<object> DeserializeObjects(string fileName);
    }
}
