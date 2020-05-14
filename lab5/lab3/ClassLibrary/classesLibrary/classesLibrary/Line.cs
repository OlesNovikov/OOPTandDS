using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesLibrary
{
    [Serializable]
    class Line : Shape
    {
        public int EndPointX { get; set; }
        public int EndPointY { get; set; }
    }
}
