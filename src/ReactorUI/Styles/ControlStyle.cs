using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
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
