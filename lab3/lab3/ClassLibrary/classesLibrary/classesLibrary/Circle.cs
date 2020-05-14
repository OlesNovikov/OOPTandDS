using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesLibrary
{
    [Serializable]
    class Circle : Shape
    {
        private float _radius;

        public float Radius
        {
            get { return _radius; }
            set
            {
                if (value < 0) _radius = (float)0.0;
                else _radius = value;
            }
        }
    }
}
