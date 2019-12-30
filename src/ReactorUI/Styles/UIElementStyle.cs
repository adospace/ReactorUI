using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
{
    public class UIElementStyle<T> : IUIElementStyle<T> where T : IUIElement
    {
        public Action<T> OnMouseEnterAction { get; set; }
        public Action<T> OnMouseLeaveAction { get; set; }
        public Action<T> OnMouseDownAction { get; set; }
        public Action<T> OnMouseUpAction { get; set; }

        public double Opacity { get; set; } = 1.0;
        public Transform Transform { get; set; } = new Transform();
    }

    public static class UIElementStyleExtensions
    {
        public static TS OnMouseEnter<TS, T>(this TS style, Action<T> action) where TS : IUIElementStyle<T> where T : IUIElement
        {
            style.OnMouseEnterAction = action;
            return style;
        }

        public static TS OnMouseLeave<TS, T>(this TS style, Action<T> action) where TS : IUIElementStyle<T> where T : IUIElement
        {
            style.OnMouseLeaveAction = action;
            return style;
        }

        public static TS OnMouseDown<TS, T>(this TS style, Action<T> action) where TS : IUIElementStyle<T> where T : IUIElement
        {
            style.OnMouseDownAction = action;
            return style;
        }

        public static TS OnMouseUp<TS, T>(this TS style, Action<T> action) where TS : IUIElementStyle<T> where T : IUIElement
        {
            style.OnMouseUpAction = action;
            return style;
        }
    }
}
