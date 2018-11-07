using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Rect
    {
        public double X { get; }
        public double Y { get; }

        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rect(double x, double y, double width, double height)
        {
            if (width < 0.0) throw new ArgumentException();
            if (height < 0.0) throw new ArgumentException();

            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Vector Location => new Vector(X, Y);
        public Size Size => new Size(Width, Height);

        public bool IsEmpty => Width < 0.0;

        public static Rect Empty { get; } = new Rect() { Width = -1.0, Height = -1.0 };

        public bool IsCloseTo(Rect other) =>
            Math.Abs(X - other.X) < 1e-10 &&
            Math.Abs(Y - other.Y) < 1e-10 &&
            Math.Abs(Width - other.Width) < 1e-10 &&
            Math.Abs(Height - other.Height) < 1e-10;

        public bool Contains(double x, double y) => x >= X && y >= Y && x <= X + Width && y <= Y + Height;
        public bool Contains(Point pt) => Contains(pt.X, pt.Y);
    }
}
