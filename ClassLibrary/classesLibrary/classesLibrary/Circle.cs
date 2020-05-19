using System;

namespace classesLibrary
{
    [Serializable]
    public class Circle : Shape
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
