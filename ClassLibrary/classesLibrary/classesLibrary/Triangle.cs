using System;

namespace classesLibrary
{
    [Serializable]
    public class Triangle : Shape
    {
        public int Point3X { get; set; }
        public int Point3Y { get; set; }
        public int Point2X { get; set; }
        public int Point2Y { get; set; }
    }
}
