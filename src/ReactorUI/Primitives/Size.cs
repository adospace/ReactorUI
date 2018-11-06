using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Size
    {
        private double _width;
        public double Width
        {
            get => _width < 0 ? throw new InvalidOperationException() : _width;
            set {
                if (value < 0)
                    throw new ArgumentException();
                _width = value;
            } 
        }
        private double _height;
        public double Height
        {
            get => _height < 0 ? throw new InvalidOperationException() : _height;
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _height = value;
            }
        }
        public Size(double width, double height)
        {
            if (width < 0.0) throw new ArgumentException();
            if (height < 0.0) throw new ArgumentException();

            _width = width;
            _height = height;
        }

        public bool IsEmpty => _width < 0.0;

        public static Size Empty { get; } = new Size() { _width = -1.0, _height = -1.0 };

        public Rect ToRect => new Rect(0.0, 0.0, Width, Height);

        public bool IsCloseTo(Size other) =>
            Math.Abs(Width - other.Width) < 1e-10 && Math.Abs(Height - other.Height) < 1e-10;
    }
}
