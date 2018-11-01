using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public interface IControl : IFrameworkElement
    {
        bool IsEnabled { get; set; }

        string FontFamily { get; set; }
        FontStyle FontStyle { get; set; }
        FontStretch FontStretch { get; set; }
        FontWeight FontWeight { get; set; }
        double FontSize { get; set; }

        Brush Foreground { get; set; }
        Brush Background { get; set; }
        Brush BorderBrush { get; set; }
        Thickness BorderThickness { get; set; }

        bool IsTabStop { get; set; }
        int TabIndex { get; set; }

        Thickness Padding { get; set; }

        HorizontalAlignment HorizontalContentAlignment { get; set; }
        VerticalAlignment VerticalContentAlignment { get; set; }


    }
}
