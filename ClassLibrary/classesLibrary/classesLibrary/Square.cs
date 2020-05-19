using System;

namespace classesLibrary
{
    [Serializable]
    public class Square : Shape
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
