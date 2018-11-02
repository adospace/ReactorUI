using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Primitives
{
    public struct CornerRadius
    {
        public CornerRadius(double uniformRadius)
        {
            TopLeft = TopRight = BottomRight = BottomLeft = uniformRadius;
        }
        public CornerRadius(double topLeft, double topRight, double bottomRight, double bottomLeft)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomRight = bottomRight;
            BottomLeft = bottomLeft;
        }

        public double TopLeft { get; set; }
        public double TopRight { get; set; }
        public double BottomRight { get; set; }
        public double BottomLeft { get; set; }
    }
}
