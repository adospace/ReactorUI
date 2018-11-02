using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public class ControlStyle<T> : FrameworkElementStyle<T> where T : IControl
    {
        public Brush Background { get; set; }
    }

    public static class ControlStyleExtensions
    {
        public static TS Background<TS, T>(this TS style, Brush brush) where TS : ControlStyle<T> where T : IControl
        {
            style.Background = brush;
            return style;
        }
    }
}
