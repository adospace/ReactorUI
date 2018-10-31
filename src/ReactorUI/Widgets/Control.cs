using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class Control<T> : Widget<T>, IControl where T : class, IControl
    {
        public bool IsEnabled { get; set; } = true;

        public string FontFamily { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontStretch FontStretch { get; set; }
        public FontWeight FontWeight { get; set; }
        public double FontSize { get; set; }

        public Brush Foreground { get; set; }
        public Brush Background { get; set; }
        public Brush BorderBrush { get; set; }
        public Thickness BorderThickness { get; set; }

        public bool IsTabStop { get; set; }
        public int TabIndex { get; set; }

        public Thickness Padding { get; set; }

        public HorizontalAlignment HorizontalContentAlignment { get; set; } = HorizontalAlignment.Stretch;
        public VerticalAlignment VerticalContentAlignment { get; set; } = VerticalAlignment.Stretch;

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield break;
        }
    }


    public static class ControlExtensions
    {
        public static Control<T> Foreground<T>(this Control<T> control, Brush foreground) where T : class, IControl
        {
            control.Foreground = foreground;
            return control;
        }

        public static Control<T> Background<T>(this Control<T> control, Brush background) where T : class, IControl
        {
            control.Background = background;
            return control;
        }

        public static Control<T> BorderBrush<T>(this Control<T> control, Brush borderBrush) where T : class, IControl
        {
            control.BorderBrush = borderBrush;
            return control;
        }

        public static Control<T> BorderThickness<T>(this Control<T> control, Thickness thickness) where T : class, IControl
        {
            control.BorderThickness = thickness;
            return control;
        }

        public static Control<T> BorderThickness<T>(this Control<T> control, double thickness) where T : class, IControl
        {
            control.BorderThickness = new Thickness(thickness);
            return control;
        }

        public static Control<T> BorderThickness<T>(this Control<T> control, double left, double top, double right, double bottom) where T : class, IControl
        {
            control.BorderThickness = new Thickness(left, top, right, bottom);
            return control;
        }

        public static Control<T> Border<T>(this Control<T> control, Brush borderBrush, double thickness) where T : class, IControl
        {
            control.BorderBrush = borderBrush;
            control.BorderThickness = new Thickness(thickness);
            return control;
        }

        public static Control<T> Border<T>(this Control<T> control, Brush borderBrush, double left, double top, double right, double bottom) where T : class, IControl
        {
            control.BorderBrush = borderBrush;
            control.BorderThickness = new Thickness(left, top, right, bottom);
            return control;
        }

        public static Control<T> Padding<T>(this Control<T> control, Thickness thickness) where T : class, IControl
        {
            control.Padding = thickness;
            return control;
        }

        public static Control<T> Padding<T>(this Control<T> control, double thickness) where T : class, IControl
        {
            control.Padding = new Thickness(thickness);
            return control;
        }

        public static Control<T> Padding<T>(this Control<T> control, double left, double top, double right, double bottom) where T : class, IControl
        {
            control.Padding = new Thickness(left, top, right, bottom);
            return control;
        }

        public static Control<T> HorizontalContentAlignment<T>(this Control<T> control, HorizontalAlignment alignment) where T : class, IControl
        {
            control.HorizontalContentAlignment = alignment;
            return control;
        }

        public static Control<T> VerticalContentAlignment<T>(this Control<T> control, VerticalAlignment alignment) where T : class, IControl
        {
            control.VerticalContentAlignment = alignment;
            return control;
        }

        public static Control<T> IsEnabled<T>(this Control<T> control, bool isEnabled) where T : class, IControl
        {
            control.IsEnabled = isEnabled;
            return control;
        }

        public static Control<T> TabIndex<T>(this Control<T> control, int tabIndex) where T : class, IControl
        {
            control.TabIndex = tabIndex;
            return control;
        }

        public static Control<T> IsTabStop<T>(this Control<T> control, bool isTabStop) where T : class, IControl
        {
            control.IsTabStop = isTabStop;
            return control;
        }

        public static Control<T> FontStyle<T>(this Control<T> control, FontStyle fontStyle) where T : class, IControl
        {
            control.FontStyle = fontStyle;
            return control;
        }

        public static Control<T> FontStretch<T>(this Control<T> control, FontStretch fontStretch) where T : class, IControl
        {
            control.FontStretch = fontStretch;
            return control;
        }

        public static Control<T> FontWeight<T>(this Control<T> control, FontWeight fontWeight) where T : class, IControl
        {
            control.FontWeight = fontWeight;
            return control;
        }

        public static Control<T> FontFamily<T>(this Control<T> control, string fontFamily) where T : class, IControl
        {
            control.FontFamily = fontFamily;
            return control;
        }

        public static Control<T> FontSize<T>(this Control<T> control, double fontSize) where T : class, IControl
        {
            control.FontSize = fontSize;
            return control;
        }

        public static Control<T> Font<T>(this Control<T> control, 
            string fontFamily, 
            double fontSize,
            FontStyle fontStyle = Primitives.FontStyle.Normal, 
            FontWeight fontWeight = Primitives.FontWeight.Normal, 
            FontStretch fontStretch = Primitives.FontStretch.Normal) where T : class, IControl
        {
            control.FontFamily = fontFamily;
            control.FontStyle = fontStyle;
            control.FontWeight = fontWeight;
            control.FontStretch = fontStretch;
            control.FontSize = fontSize;

            return control;
        }
    }
}
