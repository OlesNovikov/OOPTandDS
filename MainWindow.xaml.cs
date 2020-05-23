using myEncryption;
using mySerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace lab3
{
    public partial class MainWindow : Window
    {
        List<Type> ListOfArchivationClasses;
        List<Type> ListOfMainClasses;
        List<Type> ListOfSerializationClasses;
        List<Type> ListOfEncryptionClasses;

        Assembly ArchivationClassesAssembly;
        Assembly MainClassesAssembly;
        Assembly SerializationClassesAssembly;
        Assembly EncyptionClassesAssembly;

        Singleton list;

        static int offset = 1;
        string CurrentClassName;
        bool Edit = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateFieldsOnForm(Type currentClass, int leftMargin)
        {
            var properties = currentClass.GetProperties();

            ShapeProperties.Visibility = Visibility.Visible;
            ShapeProperties.Children.Clear();
            foreach (var property in properties)
            {
                if (property.Name == "ShapeName") ShapeProperties.Children.Add(new TextBox() { Margin = new Thickness(leftMargin, 5 * offset, 0, 0), Name = "TextBox" + property.Name, Text = CurrentClassName, IsReadOnly = true });
                else ShapeProperties.Children.Add(new TextBox() { Margin = new Thickness(leftMargin, 5 * offset, 0, 0), Name = "TextBox" + property.Name, Text = property.Name });
            }
            Button SaveBtn = new Button() { Margin = new Thickness(leftMargin, 5 * offset, 0, 0), Name = "SaveButton", Content = "Save" };
            ShapeProperties.Children.Add(SaveBtn);
            SaveBtn.Click += new RoutedEventHandler(SaveButton_Click);
        }

        public void CreateShapeAddButtons(Type currentClass, int margin)
        {
            Button AddShapeButton = new Button() { Margin = new Thickness(margin, 5 * offset, 0, 0), Name = "Add" + currentClass.Name, Content = currentClass.Name, Width = 100, Height = 25 };
            shapesGroupBox.Children.Add(AddShapeButton);
            AddShapeButton.Click += new RoutedEventHandler(AddShapeButton_Click);
        }

        public void TakeClassName()
        {
            foreach (var CurrentClass in ListOfMainClasses)
            {
                if (CurrentClassName == CurrentClass.Name) CreateFieldsOnForm(CurrentClass, 5);
            }
        }

        public void UpdateListBox()
        {
            shapeViewBox.Items.Clear();
            foreach (var item in list.ListOfObjects) shapeViewBox.Items.Add(item.GetType().Name);
        }

        public object AddFieldsToObject(Type CurrentClass, int index)
        {
            var obj = MainClassesAssembly.CreateInstance(CurrentClass.FullName);
            var properties = CurrentClass.GetProperties();
            try
            {
                foreach (var property in properties)
                {
                    if (property.Name == "ShapeName") property.SetValue(obj, CurrentClass.Name);
                    else if (property.PropertyType == typeof(int)) property.SetValue(obj, Int32.Parse(((TextBox)ShapeProperties.Children[index]).Text));
                    else if (property.PropertyType == typeof(float)) property.SetValue(obj, float.Parse(((TextBox)ShapeProperties.Children[index]).Text));
                    else if (property.PropertyType == typeof(string)) property.SetValue(obj, ((TextBox)ShapeProperties.Children[index]).Text);
                    index++;
                }
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return obj;
            }
        }

        public void SetValuesOnForm(object currentObject, int index)
        {
            var properties = currentObject.GetType().GetProperties();

            try
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(currentObject);

                    if (property.Name == "ShapeName") ((TextBox)(ShapeProperties.Children[index])).Text = CurrentClassName;
                    else if (property.PropertyType == typeof(int)) ((TextBox)(ShapeProperties.Children[index])).Text = ((int)value).ToString();
                    else if (property.PropertyType == typeof(float)) ((TextBox)(ShapeProperties.Children[index])).Text = ((float)value).ToString();
                    else if (property.PropertyType == typeof(string)) ((TextBox)(ShapeProperties.Children[index])).Text = value.ToString();
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadArchivation()
        {
            ListOfArchivationClasses = new List<Type>();
            ArchivationClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab6\lab3\ClassLibrary\Archivation\archivationClass\archivationClass\bin\Debug\archivationClass.dll");
            ListOfArchivationClasses = ArchivationClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        public void LoadMainClasses()
        {
            ListOfMainClasses = new List<Type>();
            MainClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab6\lab3\ClassLibrary\classesLibrary\classesLibrary\bin\Debug\classesLibrary.dll");
            ListOfMainClasses = MainClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        public void LoadSerialization()
        {
            ListOfSerializationClasses = new List<Type>();
            SerializationClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab6\lab3\ClassLibrary\mySerialization\mySerialization\bin\Debug\mySerialization.dll");
            ListOfSerializationClasses = SerializationClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        public void LoadEncryption()
        {
            ListOfEncryptionClasses = new List<Type>();
            EncyptionClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab6\lab3\ClassLibrary\myEncryption\myEncryption\myEncryption\bin\Debug\myEncryption.dll");
            ListOfEncryptionClasses = EncyptionClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        private void AppLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadArchivation();
                LoadMainClasses();
                LoadSerialization();
                LoadEncryption();
                list = Singleton.GetInstance();

                foreach (var classItem in ListOfMainClasses)
                {
                    if (!classItem.IsAbstract)
                    {
                        CreateShapeAddButtons(classItem, 5);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool BinarySerializationSelected()
        {
            if ((bool)BinarySerializationRadioButton.IsChecked) return true;
            else return false;
        }

        public bool TextSerializationSelected()
        {
            if ((bool)TextSerializationRadioButton.IsChecked) return true;
            else return false;
        }

        public bool ArchivationSelected()
        {
            if ((bool)ArchivationRadioButton.IsChecked) return true;
            else return false;
        }

        public bool EncryptionSelected()
        {
            if ((bool)EncryptionRadioButton.IsChecked) return true;
            else return false;
        }

        public void ArchiveFile(string FILE_NAME, string archivedFileName)
        {
            try
            {
                foreach (var classItem in ListOfArchivationClasses)
                {
                    if (classItem.Name == "Archivation")
                    {
                        var obj = ArchivationClassesAssembly.CreateInstance(classItem.FullName);

                        Type t = ArchivationClassesAssembly.GetType(classItem.FullName, true, true);

                        MethodInfo method = t.GetMethod("OnSave");
                        object callMethod = method.Invoke(obj, new object[] { FILE_NAME, archivedFileName });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        public void UnzipFile(string archivedFileName, string unzipFileName)
        {
            try
            {
                foreach (var classItem in ListOfArchivationClasses)
                {
                    if (classItem.Name == "Archivation")
                    {
                        var obj = ArchivationClassesAssembly.CreateInstance(classItem.FullName);

                        Type t = ArchivationClassesAssembly.GetType(classItem.FullName, true, true);

                        MethodInfo method = t.GetMethod("OnLoad");
                        object callMethod = method.Invoke(obj, new object[] { archivedFileName, unzipFileName });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string SerializeFile(string serializedFileName)
        {
            string result = "";
            ISerialization serialization = null;

            try
            {
                if (BinarySerializationSelected()) serialization = new BinSerialization();
                else if (TextSerializationSelected()) serialization = new myTextSerialization();
                else MessageBox.Show("Select serialization method");

                if (serialization != null)
                {
                    SerializationStrategy strategy = new SerializationStrategy(serialization);
                    result = strategy.OnSave(list.ListOfObjects, serializedFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        private List<object> DeserializeFile(string unzipFileName, string decryptedFileName)
        {
            ISerialization deserialization = null;
            try
            {
                if (BinarySerializationSelected()) deserialization = new BinSerialization();
                else if (TextSerializationSelected()) deserialization = new myTextSerialization();
                else MessageBox.Show("Select deserialization method");

                if (deserialization != null)
                {
                    SerializationStrategy strategy = new SerializationStrategy(deserialization);
                    if (ArchivationSelected())
                    {
                        list.ListOfObjects = strategy.OnLoad(unzipFileName);
                    }
                    else if (EncryptionSelected())
                    {
                        list.ListOfObjects = strategy.OnLoad(decryptedFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list.ListOfObjects;
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            string serializedFileName = "SerializedObjects.data";
            string archivedFileName = "ArchivedObjects.data";
            string encryptedFileName = "EncryptedObjects.data";

            try
            {
                if (list.ListOfObjects.Count > 0)
                {
                    string serializeResult = SerializeFile(serializedFileName);
                    MessageBox.Show(serializeResult);

                    if (ArchivationSelected()) ArchiveFile(serializedFileName, archivedFileName);
                    else if (EncryptionSelected())
                    {
                        foreach (var classItem in ListOfEncryptionClasses)
                        {
                            if (classItem.Name == "Encryption")
                            {
                                IEncryption encoder = new Encryption();
                                EncryptionAdapter adapter = new EncryptionAdapter(encoder);
                                adapter.OnSave(serializedFileName, encryptedFileName);
                            }
                        }
                    }
                    else MessageBox.Show("Select save method");
                }
                else MessageBox.Show("Nothing to save");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            string archivedFileName = "ArchivedObjects.data";
            string unzipFileName = "UnzipObjects.data";
            string encryptedFileName = "EncryptedObjects.data";
            string decryptedFileName = "DecryptedObjects.data";

            if (ArchivationSelected()) UnzipFile(archivedFileName, unzipFileName);
            else if (EncryptionSelected())
            {
                foreach (var classItem in ListOfEncryptionClasses)
                {
                    if (classItem.Name == "Encryption")
                    {
                        IEncryption encoder = new Encryption();
                        EncryptionAdapter adapter = new EncryptionAdapter(encoder);
                        adapter.OnLoad(encryptedFileName, decryptedFileName);
                    }
                }
            }
            else MessageBox.Show("Select load method");

            list.ListOfObjects = DeserializeFile(unzipFileName, decryptedFileName);

            if (list.ListOfObjects.Count > 0) MessageBox.Show("Deserialization was successful!");
            else MessageBox.Show("File is empty");
            UpdateListBox();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShapeProperties.Visibility = Visibility.Hidden;
                int index = shapeViewBox.SelectedIndex;
                shapeViewBox.Items.RemoveAt(index);
                list.ListOfObjects.RemoveAt(index);
                UpdateListBox();
            }
            catch
            {
                MessageBox.Show("First select the shape you want to delete");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = shapeViewBox.SelectedIndex;
                CurrentClassName = list.ListOfObjects[index].GetType().Name;
                TakeClassName();
                SetValuesOnForm(list.ListOfObjects[index], 0);
                Edit = true;
            }
            catch
            {
                MessageBox.Show("First select the shape you want to edit");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            object shape;
            foreach (var CurrentClass in ListOfMainClasses)
            { 
                if (CurrentClassName == CurrentClass.Name)
                {
                    shape = AddFieldsToObject(CurrentClass, 0);
                    if (!Edit) list.ListOfObjects.Add(shape);
                    else
                    {
                        int index = shapeViewBox.SelectedIndex;
                        list.ListOfObjects[index] = shape;
                    }
                }
                
            }

            UpdateListBox();
            Edit = false;
            ShapeProperties.Visibility = Visibility.Hidden;
        }

        private void AddShapeButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            for (int i = 0; i < shapesGroupBox.Children.Count; i++)
            {
                if (shapesGroupBox.Children[i].IsFocused) CurrentClassName = ((Button)shapesGroupBox.Children[i]).Content.ToString();
            }
            TakeClassName();
        }
    }
}