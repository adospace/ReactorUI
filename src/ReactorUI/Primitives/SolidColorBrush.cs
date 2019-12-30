using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public sealed class SolidColorBrush : Brush, IEquatable<SolidColorBrush>
    {
        public SolidColorBrush(Color color)
        {
            Color = color;
        }
        public SolidColorBrush(byte r, byte g, byte b)
        {
            Color = new Color(r, g, b);
        }
        public SolidColorBrush(byte a, byte r, byte g, byte b)
        {
            Color = new Color(a, r, g, b);
        }

        public Color Color { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SolidColorBrush);
        }

        public bool Equals(SolidColorBrush other)
        {
            return other != null &&
                   Color.Equals(other.Color);
        }

        public override int GetHashCode()
        {
            return -1200350280 + Color.GetHashCode();
        }

        public static bool operator ==(SolidColorBrush left, SolidColorBrush right)
        {
            return EqualityComparer<SolidColorBrush>.Default.Equals(left, right);
        }

        public static bool operator !=(SolidColorBrush left, SolidColorBrush right)
        {
            return !(left == right);
        }
    }
}
