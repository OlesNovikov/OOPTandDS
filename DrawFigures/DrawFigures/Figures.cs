using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawFigures
{
    public partial class Figures : Form
    {
        Graphics graphics;
        Shape shape;
        List<Shape> ListOfShapes = new List<Shape>();
        int x, y;
        int x1, y1;
        bool nothingChecked;
        bool isClicked = false;

        public Figures()
        {
            InitializeComponent();
        }

        private void Figures_Load(object sender, EventArgs e)
        {
            //const int LINE_WIDTH = 3;
            graphics = pictureBox1.CreateGraphics();

            /*ListOfShapes.Add(new Line(new Pen(Color.Chocolate, LINE_WIDTH), new Point(20, 20), new Point(20, 140)));
            ListOfShapes.Add(new Sqare(new Pen(Color.DimGray, LINE_WIDTH), 40, 20, 120));
            ListOfShapes.Add(new Rectangle(new Pen(Color.Aqua, LINE_WIDTH), 180, 20, 280, 120));
            ListOfShapes.Add(new Triangle(new Pen(Color.Indigo, LINE_WIDTH), new Point(100, 200), new Point(200, 300), new Point(250, 200)));
            ListOfShapes.Add(new Ellipse(new Pen(Color.LightBlue, LINE_WIDTH), 520, 120, 180, 120));
            ListOfShapes.Add(new Circle(new Pen(Color.Navy, LINE_WIDTH), 320, 190, 80));*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in ListOfShapes)
            {
                shape.Draw(graphics);
            }
        }

        public void clearPictureBox()
        {
            graphics.Clear(pictureBox1.BackColor);
        }

        private void clearField_Click(object sender, EventArgs e)
        {
            ListOfShapes.Clear();
            clearPictureBox();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
            x = e.X;
            y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                x1 = e.X;
                y1 = e.Y;
                pictureBox1.Invalidate();
            }
        }

        private void colorBox_Click(object sender, EventArgs e)
        {
            DialogResult dRes = colorDialog.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                colorBox.BackColor = colorDialog.Color;
            }
        }

        private void Figures_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
            nothingChecked = false;
            const int LINE_WIDTH = 1;
            Pen pen = new Pen(colorDialog.Color, LINE_WIDTH);
            Point startPoint = new Point(x, y);
            Point endPoint = new Point(x1, y1);

            if (lineRadioButton.Checked) ListOfShapes.Add(new Line(pen, startPoint, endPoint));
            else if (squareRadioButton.Checked) ListOfShapes.Add(new Sqare(pen, x, y, Math.Abs(x - x1)));
            else if (triangleRadioButton.Checked) ListOfShapes.Add(new Triangle(pen, startPoint, new Point(Math.Abs(x1 - y - y1), y1), new Point(Math.Abs(x1 + y - y1), y1)));
            else if (rectangleRadioButton.Checked) ListOfShapes.Add(new Rectangle(pen, x, y, Math.Abs(x - x1), Math.Abs(y - y1)));
            else if (circleRadioButton.Checked) ListOfShapes.Add(new Circle(pen, x, y, Math.Abs(x - x1)));
            else if (ellipseRadioButton.Checked) ListOfShapes.Add(new Ellipse(pen, x, y, Math.Abs(x - x1), Math.Abs(y - y1)));
            else nothingChecked = true;

            foreach (Shape shape in ListOfShapes)
            {
                shape.Draw(graphics);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            nothingChecked = false;
            const int LINE_WIDTH = 1;
            Pen pen = new Pen(colorDialog.Color, LINE_WIDTH);
            Point startPoint = new Point(x, y);
            Point endPoint = new Point(x1, y1);

            if (lineRadioButton.Checked) shape = new Line(pen, startPoint, endPoint);
            else if (squareRadioButton.Checked) shape = new Sqare(pen, x, y, Math.Abs(x - x1));
            else if (triangleRadioButton.Checked) shape = new Triangle(pen, startPoint, new Point(Math.Abs(x1 - y - y1), y1), new Point(Math.Abs(x1 + y - y1), y1));
            else if (rectangleRadioButton.Checked) shape = new Rectangle(pen, x, y, Math.Abs(x - x1), Math.Abs(y - y1));
            else if (circleRadioButton.Checked) shape = new Circle(pen, x, y, Math.Abs(x - x1));
            else if (ellipseRadioButton.Checked) shape = new Ellipse(pen, x, y, Math.Abs(x - x1), Math.Abs(y - y1));
            else nothingChecked = true;

            if (!nothingChecked)
            {
                shape.Draw(graphics);
                foreach (Shape shape in ListOfShapes)
                {
                    shape.Draw(graphics);
                }
            }
        }
    }
}
