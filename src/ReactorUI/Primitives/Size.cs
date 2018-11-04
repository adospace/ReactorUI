using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Size
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Size(double width, double height)
        {
            if (width < 0.0) throw new ArgumentException();
            if (height < 0.0) throw new ArgumentException();

            Width = width;
            Height = height;
        }

        public bool IsEmpty => Width < 0.0;

        public static Size Empty { get; } = new Size() { Width = -1.0, Height = -1.0 };

        public Rect ToRect => new Rect(0.0, 0.0, Width, Height);

        public bool IsCloseTo(Size other) =>
            Math.Abs(Width - other.Width) < 1e-10 && Math.Abs(Height - other.Height) < 1e-10;
    }
}
