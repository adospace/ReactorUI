using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
{
    public class FrameworkElementStyle<T> : UIElementStyle<T>, IFrameworkElementStyle<T> where T : IFrameworkElement
    {
        public double MaxWidth { get; set; } = double.PositiveInfinity;
        public double Width { get; set; } = double.NaN;
        public double MinWidth { get; set; }

        public double MaxHeight { get; set; } = double.PositiveInfinity;
        public double Height { get; set; } = double.NaN;
        public double MinHeight { get; set; }

        public Thickness Margin { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Stretch;
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Stretch;
    }

    public static class FrameworkElementStyleExtensions
    {
        public static TS MaxWidth<TS, T>(this TS style, double width) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.MaxWidth = width;
            return style;
        }

        public static TS Width<TS, T>(this TS style, double width) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.Width = width;
            return style;
        }

        public static TS MinWidth<TS, T>(this TS style, double width) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.MinWidth = width;
            return style;
        }

        public static TS MaxHeight<TS, T>(this TS style, double height) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.MaxHeight = height;
            return style;
        }

        public static TS Height<TS, T>(this TS style, double height) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.Height = height;
            return style;
        }

        public static TS MinHeight<TS, T>(this TS style, double height) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.MinHeight = height;
            return style;
        }

        public static TS Margin<TS, T>(this TS style, Thickness margin) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.Margin = margin;
            return style;
        }

        public static TS VerticalAlignment<TS, T>(this TS style, VerticalAlignment alignment) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.VerticalAlignment = alignment;
            return style;
        }

        public static TS HorizontalAlignment<TS, T>(this TS style, HorizontalAlignment alignment) where TS : FrameworkElementStyle<T> where T : IControl
        {
            style.HorizontalAlignment = alignment;
            return style;
        }
    }

}
