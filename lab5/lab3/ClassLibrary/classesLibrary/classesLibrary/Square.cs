using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesLibrary
{
    [Serializable]
    class Square : Shape
    {
        private float _sideWidth;
        public float SideWidth
        {
            get { return _sideWidth; }
            set
            {
                if (value < 0) _sideWidth = (float)0.0;
                else _sideWidth = value;
            }
        }
    }
}
