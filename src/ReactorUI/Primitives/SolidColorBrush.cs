using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public sealed class SolidColorBrush : Brush
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
    }
}
