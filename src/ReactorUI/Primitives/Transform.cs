using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorUI.Primitives
{
    public class Transform
    {
        public abstract class Operation
        { }

        public class Translate : Operation
        {
            public Translate(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }
        }

        public class Rotate : Operation
        { 
            public Rotate(double degrees)
            {
                Degrees = degrees;
            }

            public double Degrees { get; }
        }

        public class RotateRelativeOrigin : Operation
        {
            public RotateRelativeOrigin(double degrees, double xOffset, double yOffset)
            {
                Degrees = degrees;
                XOffset = xOffset;
                YOffset = yOffset;
            }

            public double Degrees { get; }
            public double XOffset { get; }
            public double YOffset { get; }
        }

        public class RotateOrigin : Operation
        {
            public RotateOrigin(double degrees, double x, double y)
            {
                Degrees = degrees;
                X = x;
                Y = y;
            }

            public double Degrees { get; }
            public double X { get; }
            public double Y { get; }
        }

        public class Scale : Operation
        {
            public Scale(double x, double y)
            {
                if (x < 0) throw new ArgumentOutOfRangeException();
                if (y < 0) throw new ArgumentOutOfRangeException();
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }
        }

        public class ScaleOrigin : Operation
        {
            public ScaleOrigin(double x, double y, double xOrigin, double yOrigin)
            {
                if (x < 0) throw new ArgumentOutOfRangeException();
                if (y < 0) throw new ArgumentOutOfRangeException();
                X = x;
                Y = y;
                XOrigin = xOrigin;
                YOrigin = yOrigin;
            }

            public double X { get; }
            public double Y { get; }
            public double XOrigin { get; }
            public double YOrigin { get; }
        }

        public class ScaleRelativeOrigin : Operation
        {
            public ScaleRelativeOrigin(double x, double y, double xOffset, double yOffset)
            {
                if (x < 0) throw new ArgumentOutOfRangeException();
                if (y < 0) throw new ArgumentOutOfRangeException();
                X = x;
                Y = y;
                XOffset = xOffset;
                YOffset = yOffset;
            }

            public double X { get; }
            public double Y { get; }
            public double XOffset { get; }
            public double YOffset { get; }
        }

        public class Skew : Operation
        {
            public Skew(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }
        }

        Queue<Operation> _operations = new Queue<Operation>();
        public IReadOnlyList<Operation> Operations
        {
            get => _operations.ToList();
        }

        public void Enqueue(Operation operation)
        {
            _operations.Enqueue(operation);
        }

        public Transform()
        {

        }

    }
}
