using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class Control<T, TS> : FrameworkElement<T, TS>, IControl where T : class, IControl where TS : ControlStyle<T>
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

        public bool IsTabStop { get; set; }
        public int TabIndex { get; set; }

        public Thickness Padding { get; set; }

        public HorizontalAlignment HorizontalContentAlignment { get; set; } = HorizontalAlignment.Stretch;
        public VerticalAlignment VerticalContentAlignment { get; set; } = VerticalAlignment.Stretch;

        protected override void OnApplyStyle()
        {


            base.OnApplyStyle();
        }
    }


    public static class ControlExtensions
    {
        public static T Foreground<T>(this T control, Brush foreground) where T : class, IControl
        {
            control.Foreground = foreground;
            return control;
        }

        public static T Background<T>(this T control, Brush background) where T : class, IControl
        {
            control.Background = background;
            return control;
        }

        public static T Background<T>(this T control, Color backgroundColor) where T : class, IControl
        {
            control.Background = new SolidColorBrush(backgroundColor);
            return control;
        }

        public static T Background<T>(this T control, byte r, byte g, byte b) where T : class, IControl
        {
            control.Background = new SolidColorBrush(Color.FromRGB(r, g, b));
            return control;
        }

        public static T Background<T>(this T control, byte a, byte r, byte g, byte b) where T : class, IControl
        {
            control.Background = new SolidColorBrush(Color.FromARGB(a, r, g, b));
            return control;
        }

        public static T BorderBrush<T>(this T control, Brush borderBrush) where T : class, IControl
        {
            control.BorderBrush = borderBrush;
            return control;
        }

        public static T BorderThickness<T>(this T control, Thickness thickness) where T : class, IControl
        {
            control.BorderThickness = thickness;
            return control;
        }

        public static T BorderThickness<T>(this T control, double thickness) where T : class, IControl
        {
            control.BorderThickness = new Thickness(thickness);
            return control;
        }

        public static T BorderThickness<T>(this T control, double left, double top, double right, double bottom) where T : class, IControl
        {
            control.BorderThickness = new Thickness(left, top, right, bottom);
            return control;
        }

        public static T Border<T>(this T control, Brush borderBrush, double thickness) where T : class, IControl
        {
            control.BorderBrush = borderBrush;
            control.BorderThickness = new Thickness(thickness);
            return control;
        }

        public static T Border<T>(this T control, Brush borderBrush, double left, double top, double right, double bottom) where T : class, IControl
        {
            control.BorderBrush = borderBrush;
            control.BorderThickness = new Thickness(left, top, right, bottom);
            return control;
        }

        public static T Padding<T>(this T control, Thickness thickness) where T : class, IControl
        {
            control.Padding = thickness;
            return control;
        }

        public static T Padding<T>(this T control, double thickness) where T : class, IControl
        {
            control.Padding = new Thickness(thickness);
            return control;
        }

        public static T Padding<T>(this T control, double left, double top, double right, double bottom) where T : class, IControl
        {
            control.Padding = new Thickness(left, top, right, bottom);
            return control;
        }

        public static T HorizontalContentAlignment<T>(this T control, HorizontalAlignment alignment) where T : class, IControl
        {
            control.HorizontalContentAlignment = alignment;
            return control;
        }

        public static T VerticalContentAlignment<T>(this T control, VerticalAlignment alignment) where T : class, IControl
        {
            control.VerticalContentAlignment = alignment;
            return control;
        }

        public static T IsEnabled<T>(this T control, bool isEnabled) where T : class, IControl
        {
            control.IsEnabled = isEnabled;
            return control;
        }

        public static T TabIndex<T>(this T control, int tabIndex) where T : class, IControl
        {
            control.TabIndex = tabIndex;
            return control;
        }

        public static T IsTabStop<T>(this T control, bool isTabStop) where T : class, IControl
        {
            control.IsTabStop = isTabStop;
            return control;
        }

        public static T FontStyle<T>(this T control, FontStyle fontStyle) where T : class, IControl
        {
            control.FontStyle = fontStyle;
            return control;
        }

        public static T FontStretch<T>(this T control, FontStretch fontStretch) where T : class, IControl
        {
            control.FontStretch = fontStretch;
            return control;
        }

        public static T FontWeight<T>(this T control, FontWeight fontWeight) where T : class, IControl
        {
            control.FontWeight = fontWeight;
            return control;
        }

        public static T FontFamily<T>(this T control, string fontFamily) where T : class, IControl
        {
            control.FontFamily = fontFamily;
            return control;
        }

        public static T FontSize<T>(this T control, double fontSize) where T : class, IControl
        {
            control.FontSize = fontSize;
            return control;
        }

        public static T Font<T>(this T control, 
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
