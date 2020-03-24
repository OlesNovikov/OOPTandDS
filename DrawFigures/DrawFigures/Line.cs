using System.Drawing;
using System.Windows.Forms;


namespace DrawFigures
{
    class Line : Shape
    {
        public Point pt1;
        public Point pt2;
        public Pen pen;

        public Line (Pen pen, Point pt1, Point pt2) 
        {
            this.pen = pen;
            this.pt1 = pt1;
            this.pt2 = pt2;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(pen, pt1, pt2);
        }
    }
}
