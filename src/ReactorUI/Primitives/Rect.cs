using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Rect : IEquatable<Rect>
    {
        public double X { get; }
        public double Y { get; }

        public double Width { get; private set; }
        public double Height { get; private set; }

        [System.Diagnostics.DebuggerStepThrough]
        public Rect(double x, double y, double width, double height)
        {
            if (width < 0.0) throw new ArgumentException();
            if (height < 0.0) throw new ArgumentException();

            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public Rect(Point xy, Size size)
        {
            X = xy.X;
            Y = xy.Y;
            Width = size.Width;
            Height = size.Height;
        }

        public Vector Location => new Vector(X, Y);

        public Size Size => new Size(Width, Height);

        public bool IsEmpty => Width < 0.0;

        public static Rect Empty { get; } = new Rect() { Width = -1.0, Height = -1.0 };

        [System.Diagnostics.DebuggerStepThrough]
        public bool IsCloseTo(Rect other) =>
            Math.Abs(X - other.X) < 1e-10 &&
            Math.Abs(Y - other.Y) < 1e-10 &&
            Math.Abs(Width - other.Width) < 1e-10 &&
            Math.Abs(Height - other.Height) < 1e-10;

        [System.Diagnostics.DebuggerStepThrough]
        public bool Contains(double x, double y) => x >= X && y >= Y && x <= X + Width && y <= Y + Height;

        [System.Diagnostics.DebuggerStepThrough]
        public bool Contains(Point pt) => Contains(pt.X, pt.Y);

        public override bool Equals(object obj)
        {
            return obj is Rect rect && Equals(rect);
        }

        public bool Equals(Rect other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Width == other.Width &&
                   Height == other.Height &&
                   EqualityComparer<Vector>.Default.Equals(Location, other.Location) &&
                   EqualityComparer<Size>.Default.Equals(Size, other.Size) &&
                   IsEmpty == other.IsEmpty;
        }

        public override int GetHashCode()
        {
            var hashCode = -545639716;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + Location.GetHashCode();
            hashCode = hashCode * -1521134295 + Size.GetHashCode();
            hashCode = hashCode * -1521134295 + IsEmpty.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Rect left, Rect right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rect left, Rect right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"({X},{Y}),[{Width},{Height}]";
        }
    }
}
