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

        public Color Color { get; }
    }
}
