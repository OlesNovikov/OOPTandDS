using lab3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace mySerialization
{
    class myTextSerialization : Serialization
    {
        Assembly MainClassesAssembly;
        List<Type> ListOfMainClasses;

        public override string OnSave(List<object> listOfObjects, string fileName)
        {
                using (StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.Default))
                {
                    foreach (var obj in listOfObjects)
                    {
                        var properties = obj.GetType().GetProperties();
                        string objectType = obj.GetType().FullName;
                        streamWriter.WriteLine(objectType);
                        foreach (var property in properties)
                        {
                            var value = property.GetValue(obj);
                            streamWriter.WriteLine(property.PropertyType.Name + ": " + value.ToString());
                        }

                    }

                }
                return "Serialization was successful!";
        }

        public void LoadMainClasses()
        {
            ListOfMainClasses = new List<Type>();
            MainClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab6\lab3\ClassLibrary\classesLibrary\classesLibrary\bin\Debug\classesLibrary.dll");
            ListOfMainClasses = MainClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        public override List<object> OnLoad(string fileName)
        {
            LoadMainClasses();
            List<object> receivedObjects = new List<object>();

            PropertyInfo[] properties = null;
            object obj = null;
            Type CurrentClass = null;
            int currentPropertyIndex = 0;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    
                    string line = sr.ReadLine();
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if ((properties != null) && (currentPropertyIndex <= (properties.Count() - 1)))
                    {
                            if (properties[currentPropertyIndex].Name == "ShapeName") properties[currentPropertyIndex].SetValue(obj, CurrentClass.Name);
                            else if (properties[currentPropertyIndex].PropertyType == typeof(int)) properties[currentPropertyIndex].SetValue(obj, Int32.Parse(words[1]));
                            else if (properties[currentPropertyIndex].PropertyType == typeof(float)) properties[currentPropertyIndex].SetValue(obj, float.Parse(words[1]));
                            else if (properties[currentPropertyIndex].PropertyType == typeof(string)) properties[currentPropertyIndex].SetValue(obj, words[1]);
                            currentPropertyIndex++;
                    }
                    else
                    {
                        if (obj != null) receivedObjects.Add(obj);
                        foreach (var classItem in ListOfMainClasses)
                        {
                            if (line == classItem.ToString())
                            {
                                CurrentClass = classItem;
                                //if (receivedObjects.Count != 0) receivedObjects.Add(obj);
                                obj = MainClassesAssembly.CreateInstance(classItem.FullName);
                                properties = classItem.GetProperties();

                            }
                        }
                        currentPropertyIndex = 0;
                    }
                }
            }
            if (obj != null) receivedObjects.Add(obj);
            return receivedObjects;
        }
    }
}
