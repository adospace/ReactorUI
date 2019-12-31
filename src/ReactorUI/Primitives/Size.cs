using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Size : IEquatable<Size>
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
                _height =  value;
            }
        }
        public Size(double width, double height)
        {
            if (width < 0.0) throw new ArgumentException();
            if (height < 0.0) throw new ArgumentException();

            _width = width;
            _height = height;
        }

        public bool IsEmpty => _width == 0.0 && _height == 0.0;

        //public static Size Empty { get; } = new Size() { _width = -1.0, _height = -1.0 };

        public Rect ToRect => new Rect(0.0, 0.0, Width, Height);

        public bool IsCloseTo(Size other) =>
            Math.Abs(Width - other.Width) < 1e-10 && Math.Abs(Height - other.Height) < 1e-10;

        public bool Contains(double x, double y) => !IsEmpty && x >= 0 && y >= 0 && x <= Width && y <= Height;

        public override string ToString()
        {
            return $"[{Width},{Height}]";
        }

        public override bool Equals(object obj)
        {
            return obj is Size size && Equals(size);
        }

        public bool Equals(Size other)
        {
            return _width == other._width &&
                   Width == other.Width &&
                   _height == other._height &&
                   Height == other.Height &&
                   IsEmpty == other.IsEmpty &&
                   ToRect.Equals(other.ToRect);
        }

        public override int GetHashCode()
        {
            var hashCode = 1947661368;
            hashCode = hashCode * -1521134295 + _width.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + _height.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            hashCode = hashCode * -1521134295 + IsEmpty.GetHashCode();
            hashCode = hashCode * -1521134295 + ToRect.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Size left, Size right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Size left, Size right)
        {
            return !(left == right);
        }
    }
}
