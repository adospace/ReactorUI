using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class FrameworkElement<T, TS> : UIElement<T, TS>, IFrameworkElement where T : class, IFrameworkElement where TS : FrameworkElementStyle<T>
    {
        public double Width { get; set; } = double.NaN;
        public double MinWidth { get; set; }
        public double MaxHeight { get; set; } = double.PositiveInfinity;
        public double Height { get; set; } = double.NaN;
        public double MinHeight { get; set; }
        public double MaxWidth { get; set; } = double.PositiveInfinity;
        public Thickness Margin { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Stretch;
        public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Stretch;

        protected override void OnStyleApplied(TS styleToApply)
        {
            Width = styleToApply.Width;
            MinWidth = styleToApply.MinWidth;
            MaxHeight = styleToApply.MaxHeight;
            Height = styleToApply.Height;
            MinHeight = styleToApply.MinHeight;
            MaxWidth = styleToApply.MaxWidth;
            Margin = styleToApply.Margin;
            VerticalAlignment = styleToApply.VerticalAlignment;
            HorizontalAlignment = styleToApply.HorizontalAlignment;

            base.OnStyleApplied(styleToApply);
        }
    }


    public static class FrameworkElementExtentsions
    {
        public static T Width<T>(this T element, double width) where T : class, IFrameworkElement
        {
            element.Width = width;
            return element;
        }

        public static T MinWidth<T>(this T element, double minWidth) where T : class, IFrameworkElement
        {
            element.MinWidth = minWidth;
            return element;
        }

        public static T MaxHeight<T>(this T element, double maxHeight) where T : class, IFrameworkElement
        {
            element.MaxHeight = maxHeight;
            return element;
        }

        public static T Height<T>(this T element, double height) where T : class, IFrameworkElement
        {
            element.Height = height;
            return element;
        }

        public static T MinHeight<T>(this T element, double minHeight) where T : class, IFrameworkElement
        {
            element.MinHeight = minHeight;
            return element;
        }

        public static T MaxWidth<T>(this T element, double maxWidth) where T : class, IFrameworkElement
        {
            element.MaxWidth = maxWidth;
            return element;
        }

        public static T Margin<T>(this T element, Thickness margin) where T : class, IFrameworkElement
        {
            element.Margin = margin;
            return element;
        }

        public static T Margin<T>(this T element, double marginValue) where T : class, IFrameworkElement
        {
            element.Margin = new Thickness(marginValue);
            return element;
        }

        public static T Margin<T>(this T element, double left, double top, double right, double bottom) where T : class, IFrameworkElement
        {
            element.Margin = new Thickness(left, top, right, bottom);
            return element;
        }

        public static T VerticalAlignment<T>(this T element, VerticalAlignment verticalAlignment) where T : class, IFrameworkElement
        {
            element.VerticalAlignment = verticalAlignment;
            return element;
        }

        public static T HorizontalAlignment<T>(this T element, HorizontalAlignment horizontalAlignment) where T : class, IFrameworkElement
        {
            element.HorizontalAlignment = horizontalAlignment;
            return element;
        }

    }
}
