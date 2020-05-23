using lab3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace mySerialization
{
    public class BinSerialization : ISerialization
    {
        public string OnSave(List<object> listOfObjects, string fileName)
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

        public List<object> OnLoad(string fileName)
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
