using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Point : IEquatable<Point>
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point && Equals(point);
        }

        public bool Equals(Point other)
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

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public static Vector operator -(Point left, Point right)
        {
            return new Vector(left.X - right.X, left.Y - right.Y);
        }

        public static Vector operator +(Point left, Point right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y);
        }
    }
}
