using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Rect
    {
        public double X { get; }
        public double Y { get; }

        public double Width { get; }
        public double Height { get; }

        public Rect(double x, double y, double width, double height)
        {
            if (width < 0.0) throw new ArgumentException();
            if (height < 0.0) throw new ArgumentException();

            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Point Location => new Point(X, Y);
        public Size Size => new Size(Width, Height);
    }
}
