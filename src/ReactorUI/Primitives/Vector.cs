using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Vector : IEquatable<Vector>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsCloseTo(Vector other) =>
            Math.Abs(X - other.X) < 1e-10 && Math.Abs(Y - other.Y) < 1e-10;

        public Vector MinMax(Size minSize, Size maxSize)
        {
            return new Vector(
                Math.Max(minSize.Width, Math.Min(maxSize.Width, X)),
                Math.Max(minSize.Height, Math.Min(maxSize.Height, Y)));
        }

        public override bool Equals(object obj)
        {
            return obj is Vector vector && Equals(vector);
        }

        public bool Equals(Vector other)
        {
            return X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Vector left, Vector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector left, Vector right)
        {
            return !(left == right);
        }

        public override string ToString() => $"/{X}:{Y}/";


        public static Vector operator -(Vector left, Vector right)
        {
            return new Vector(left.X - right.X, left.Y - right.Y);
        }

        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y);
        }

        public static Vector operator *(Vector left, double v)
        {
            return new Vector(left.X * v, left.Y * v);
        }

        public static Vector operator /(Vector left, double v)
        {
            return new Vector(left.X / v, left.Y / v);
        }
    }
}
