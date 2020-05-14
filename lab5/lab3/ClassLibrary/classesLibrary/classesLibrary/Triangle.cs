using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesLibrary
{
    [Serializable]
    class Triangle : Shape
    {
        public int Point3X { get; set; }
        public int Point3Y { get; set; }
        public int Point2X { get; set; }
        public int Point2Y { get; set; }
    }
}
