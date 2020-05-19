using System;

namespace classesLibrary
{
    [Serializable]
    public class Rectangle : Shape
    {
        private float _width;
        public float Width
        {
            get {return _width; }
            set
            {
                if (value < 0) _width = (float)0.0;
                else _width = value;
            }
        }

        private float _height;
        public float Height
        {
            get { return _height; }
            set
            {
                if (value < 0) _height = (float)0.0;
                else _height = value;
            }
        }
    }
}
