using System.Collections.Generic;

namespace lab3
{
    public interface ISerialization
    {
        string OnSave(List<object> listOfObjects, string fileName);
        List<object> OnLoad(string fileName);
    }
}
