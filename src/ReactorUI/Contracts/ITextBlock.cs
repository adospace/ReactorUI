using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface ITextBlock : IFrameworkElement
    {
        string Text { get; set; }

        FontWeight FontWeight { get; set; }
        FontStyle FontStyle { get; set; }
        string FontFamily { get; set; }
        FontStretch FontStretch { get; set; }
        double BaselineOffset { get; set; }
        double FontSize { get; set; }
        TextWrapping TextWrapping { get; set; }
        Brush Background { get; set; }
        double LineHeight { get; set; }
        Thickness Padding { get; set; }
        TextAlignment TextAlignment { get; set; }
        TextTrimming TextTrimming { get; set; }

        Brush Foreground { get; set; }
    }
}
