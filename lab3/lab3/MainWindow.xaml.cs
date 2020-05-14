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

namespace lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Type> ListOfClasses;
        const string FILE_NAME = "SerializedObjects.bindata";
        public List<object> ListOfObjects;
        static Assembly ClassesAssembly;
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

        public void TakeClassName()
        {
            foreach (var CurrentClass in ListOfClasses)
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
            var obj = ClassesAssembly.CreateInstance(CurrentClass.FullName);
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

        private void AppLoaded(object sender, RoutedEventArgs e)
        {
            ListOfClasses = new List<Type>();
            ListOfObjects = new List<object>();
            ClassesAssembly = Assembly.LoadFile(@"D:\Oles\БГУИР\2 курс\4 сем\ООТПиСП\лабы\lab3\lab3\ClassLibrary\classesLibrary\classesLibrary\bin\Debug\classesLibrary.dll");
            ListOfClasses = ClassesAssembly.GetTypes().Where(type => type.IsClass).ToList();
        }

        private void AddLineButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            CurrentClassName = addLineButton.Content.ToString();
            TakeClassName();
        }

        private void AddSquareButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            CurrentClassName = addSquareButton.Content.ToString();
            TakeClassName();
        }

        private void AddRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            CurrentClassName = addRectangleButton.Content.ToString();
            TakeClassName();
        }

        private void AddTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            CurrentClassName = addTriangleButton.Content.ToString();
            TakeClassName();
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            CurrentClassName = addCircleButton.Content.ToString();
            TakeClassName();
        }

        private void AddEllipseButton_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            CurrentClassName = addEllipseButton.Content.ToString();
            TakeClassName();
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            ISerialization serializer;
            serializer = new BinSerialization();
            string SerializeResult = serializer.SerializeObjects(ListOfObjects, FILE_NAME);

            if (SerializeResult == "Serialization was successful!") MessageBox.Show(SerializeResult);
            else MessageBox.Show(SerializeResult);
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            ISerialization deserializer;
            deserializer = new BinSerialization();
            ListOfObjects = deserializer.DeserializeObjects(FILE_NAME);

            if (ListOfObjects.Count > 0) MessageBox.Show("Deserialization was successful!");
            UpdateListBox();
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
            int index = shapeViewBox.SelectedIndex;
            CurrentClassName = ListOfObjects[index].GetType().Name;
            TakeClassName();
            SetValuesOnForm(ListOfObjects[index], 0);
            Edit = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            object shape;
            foreach (var CurrentClass in ListOfClasses)
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
    }
}
