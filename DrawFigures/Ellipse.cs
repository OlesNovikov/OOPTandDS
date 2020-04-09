using System.Drawing;

namespace DrawFigures
{
    class Ellipse : Shape
    {
        private int x, y, height, width;
        public Pen pen;

        public Ellipse(Pen pen, int x, int y, int height, int width)
        {
            this.pen = pen;
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(pen, x, y, height, width);
        }
    }
}
