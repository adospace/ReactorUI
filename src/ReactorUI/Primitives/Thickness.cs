using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Thickness
    {
        public Thickness(double uniformLength)
        {
            Left = Top = Right = Bottom = uniformLength;
        }

        public Thickness(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public double Left { get; private set; }

        public double Top { get; private set; }

        public double Right { get; private set; }

        public double Bottom { get; private set; }

        public bool IsCloseTo(Thickness other) =>
            Math.Abs(Left - other.Left) < 1e-10 &&
            Math.Abs(Top - other.Top) < 1e-10 &&
            Math.Abs(Right - other.Right) < 1e-10 &&
            Math.Abs(Bottom - other.Bottom) < 1e-10;

        public Size ToSize() => new Size(Left + Right, Top + Bottom);

        public bool IsUniformLength => (Left == Right && Left == Top && Left == Bottom);

        public double UniformLength => IsUniformLength ? Left : throw new InvalidOperationException();

        public bool Any() => Left > 0.0 || Right > 0.0 || Top > 0.0 || Bottom > 0.0;
    }
}
