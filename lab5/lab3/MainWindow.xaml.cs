using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mySerialization;
using archivationClass;

namespace lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Type> ListOfArchivationClasses;
        List<Type> ListOfMainClasses;
        List<Type> ListOfSerializationClasses;
        Assembly ArchivationClassesAssembly;
        Assembly MainClassesAssembly;
        Assembly SerializationClassesAssembly;
        public List<object> ListOfObjects = new List<object>();
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
            foreach (var item in ListOfObjects) shapeViewBox.Items.Add(item.GetType().Name);
        }

        public object AddFieldsToObject(Type CurrentClass, int index)
        {
            var obj = MainClassesAssembly.CreateInstance(CurrentClass.FullName);
            var properties = CurrentClass.GetProperties();

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

        public void SetValuesOnForm(object currentObject, int index)
        {
            var properties = currentObject.GetType().GetProperties();

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

        public void LoadArchivation()
        {
            ListOfArchivationClasses = new List<Type>();
            ArchivationClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab5\lab3\ClassLibrary\Archivation\archivationClass\archivationClass\bin\Debug\archivationClass.dll");
            ListOfArchivationClasses = ArchivationClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        public void LoadMainClasses()
        {
            ListOfMainClasses = new List<Type>();
            MainClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab5\lab3\ClassLibrary\classesLibrary\classesLibrary\bin\Debug\classesLibrary.dll");
            ListOfMainClasses = MainClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        public void LoadSerialization()
        {
            ListOfSerializationClasses = new List<Type>();
            SerializationClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab5\lab3\ClassLibrary\mySerialization\mySerialization\bin\Debug\mySerialization.dll");
            ListOfSerializationClasses = SerializationClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        private void AppLoaded(object sender, RoutedEventArgs e)
        {
            LoadArchivation();
            LoadMainClasses();
            LoadSerialization();

            foreach (var classItem in ListOfMainClasses)
            {
                if (!classItem.IsAbstract)
                {
                    CreateShapeAddButtons(classItem, 5);
                }
            }
        }

        public void SerializeFile(string FILE_NAME)
        {
            try
            {
                foreach (var listItem in ListOfSerializationClasses)
                {
                    if (listItem.Name == "BinSerialization")
                    {
                        var obj = SerializationClassesAssembly.CreateInstance(listItem.FullName);

                        Type t = SerializationClassesAssembly.GetType(listItem.FullName, true, true);

                        MethodInfo method = t.GetMethod("SerializeObjects");
                        object callMethod = method.Invoke(obj, new object[] { ListOfObjects, FILE_NAME });
                        MessageBox.Show(callMethod.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DeserializeFile(string FILE_NAME)
        {
            try
            {
                foreach (var listItem in ListOfSerializationClasses)
                {
                    if (listItem.Name == "BinSerialization")
                    {
                        var obj = SerializationClassesAssembly.CreateInstance(listItem.FullName);

                        Type t = SerializationClassesAssembly.GetType(listItem.FullName, true, true);

                        MethodInfo method = t.GetMethod("DeserializeObjects");
                        ListOfObjects = (List<object>)method.Invoke(obj, new object[] { FILE_NAME });

                        if (ListOfObjects.Count >= 0) MessageBox.Show("Deserialization was successful!");
                        UpdateListBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

                        MethodInfo method = t.GetMethod("CompressFile");
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

                        MethodInfo method = t.GetMethod("DecompressFile");
                        object callMethod = method.Invoke(obj, new object[] { archivedFileName, unzipFileName });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            string FILE_NAME = "SerializedObjects.bindata";
            string archivedFileName = "Archived" + FILE_NAME;
            SerializeFile(FILE_NAME);
            ArchiveFile(FILE_NAME, archivedFileName);
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            string FILE_NAME = "SerializedObjects.bindata";
            string archivedFileName = "Archived" + FILE_NAME;
            string unzipFileName = "Unzip" + FILE_NAME;
            DeserializeFile(FILE_NAME);
            UnzipFile(archivedFileName, unzipFileName);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShapeProperties.Visibility = Visibility.Hidden;
                int index = shapeViewBox.SelectedIndex;
                shapeViewBox.Items.RemoveAt(index);
                ListOfObjects.RemoveAt(index);
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
                CurrentClassName = ListOfObjects[index].GetType().Name;
                TakeClassName();
                SetValuesOnForm(ListOfObjects[index], 0);
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
                    if (!Edit) ListOfObjects.Add(shape);
                    else
                    {
                        int index = shapeViewBox.SelectedIndex;
                        ListOfObjects[index] = shape;
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
                if (shapesGroupBox.Children[i].IsFocused)
                {
                    CurrentClassName = ((Button)shapesGroupBox.Children[i]).Content.ToString();
                }
            }
            TakeClassName();
        }
    }
}
