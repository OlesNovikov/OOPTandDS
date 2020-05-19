using System;
using System.Text.RegularExpressions;

namespace classesLibrary
{
    [Serializable]
    public abstract class Shape
    {
        private string _shapeName;
        public string ShapeName
        {
            get { return _shapeName; }
            set
            {
                if (!Regex.IsMatch(value, @"^([a-zA-Z]+\s*)+$")) _shapeName = "INCORRECT_NAME";
                else _shapeName = value;
            }
        }

        public int StartPointX { get; set; }
        public int StartpointY { get; set; }

        private string _penColor;
        public string PenColor
        {
            get { return _penColor; }
            set
            {
                if (!Regex.IsMatch(value, @"^([a-zA-Z]+\s*)+$")) _penColor = "INCORRECT_COLOR";
                else _penColor = value;
            }
        }

        private float _penWidth;
        public float PenWidth
        {
            get { return _penWidth; }
            set
            {
                if (value < 0) _penWidth = (float)0.0;
                else _penWidth = value;
            }
        }
    }
}
