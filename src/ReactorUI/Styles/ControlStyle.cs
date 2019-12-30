using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
{
    public class ControlStyle<T> : FrameworkElementStyle<T>, IControlStyle<T> where T : IControl
    {
        public string FontFamily { get; set; }
        public FontStyle FontStyle { get; set; } = FontStyle.Normal;
        public FontStretch FontStretch { get; set; } = FontStretch.Normal;
        public FontWeight FontWeight { get; set; } = FontWeight.Normal;
        public double FontSize { get; set; } = 12;

        public Brush Foreground { get; set; } = new SolidColorBrush(Color.FromRGB(0, 0, 0));
        public Brush Background { get; set; }
        public Brush BorderBrush { get; set; }
        public Thickness BorderThickness { get; set; }

        public Thickness Padding { get; set; }

        public HorizontalAlignment HorizontalContentAlignment { get; set; } = HorizontalAlignment.Stretch;
        public VerticalAlignment VerticalContentAlignment { get; set; } = VerticalAlignment.Stretch;

    }

    public static class ControlStyleExtensions
    {
        public static TS Background<TS, T>(this TS style, Brush brush) where TS : IControlStyle<T> where T : IControl
        {
            style.Background = brush;
            return style;
        }

        public static TS Foreground<TS, T>(this TS style, Brush brush) where TS : IControlStyle<T> where T : IControl
        {
            style.Foreground = brush;
            return style;
        }

        public static TS BorderBrush<TS, T>(this TS style, Brush brush) where TS : IControlStyle<T> where T : IControl
        {
            style.BorderBrush = brush;
            return style;
        }

        public static TS BorderThickness<TS, T>(this TS style, Thickness thickness) where TS : IControlStyle<T> where T : IControl
        {
            style.BorderThickness = thickness;
            return style;
        }

        public static TS BorderThickness<TS, T>(this TS style, double thickness) where TS : IControlStyle<T> where T : IControl
        {
            style.BorderThickness = new Thickness(thickness);
            return style;
        }


        public static TS Padding<TS, T>(this TS style, Thickness padding) where TS : IControlStyle<T> where T : IControl
        {
            style.Padding = padding;
            return style;
        }

        public static TS Padding<TS, T>(this TS style, double left, double top, double right, double bottom) where TS : IControlStyle<T> where T : IControl
        {
            style.Padding = new Thickness(left, top, right, bottom);
            return style;
        }

        public static TS Padding<TS, T>(this TS style, double leftRight, double topBottom) where TS : IControlStyle<T> where T : IControl
        {
            style.Padding = new Thickness(leftRight, topBottom, leftRight, topBottom);
            return style;
        }

        public static TS Padding<TS, T>(this TS style, double uniformLength) where TS : IControlStyle<T> where T : IControl
        {
            style.Padding = new Thickness(uniformLength);
            return style;
        }
    }
}
