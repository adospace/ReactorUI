using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IScrollBar : IControl
    {
        Orientation Orientation { get; set; }
        double Offset { get; set; }
        double Viewport { get; set; }
        double Extent { get; set; }
        Brush ThumbBrush { get; set; }
    }
}
