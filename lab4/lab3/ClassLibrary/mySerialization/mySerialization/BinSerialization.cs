using classesLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace mySerialization
{
    public class BinSerialization : ISerialization
    {
        public string SerializeObjects(List<object> listOfObjects, string fileName)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream FileToSerialize = new FileStream(fileName, FileMode.OpenOrCreate);

                using (FileToSerialize)
                {
                    formatter.Serialize(FileToSerialize, listOfObjects);
                }

                return "Serialization was successful!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<object> DeserializeObjects(string fileName)
        {
            List<object> listOfObjects = new List<object>();
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream FileToDeserialize = new FileStream(fileName, FileMode.Open);

                using (FileToDeserialize)
                {
                    var deserializedObjects = (List<object>)formatter.Deserialize(FileToDeserialize);
                    foreach (var obj in deserializedObjects)
                    {
                        listOfObjects.Add(obj);
                    }
                }
                return listOfObjects;
            }
            catch
            {
                return listOfObjects;
            }

        }
    }
}
