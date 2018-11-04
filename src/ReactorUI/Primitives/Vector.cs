using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Vector
    {
        public double X { get; }
        public double Y { get; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector Add(Vector vector)
        {
            return Add(vector.X, vector.Y);
        }

        public Vector Add(double x, double y)
        {
            return new Vector(X + x, Y + y);
        }

    }
}
