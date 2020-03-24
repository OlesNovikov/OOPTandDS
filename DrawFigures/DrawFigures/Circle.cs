using System.Drawing;

namespace DrawFigures
{
    class Circle : Shape
    {
        private int x, y, len;
        public Pen pen;

        public Circle(Pen pen, int x, int y, int len)
        {
            this.pen = pen;
            this.x = x;
            this.y = y;
            this.len = len;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(pen, x, y, len, len);
        }
    }
}
