using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public class UIElementStyle<T> where T : IUIElement
    {
        public Action<T> OnMouseEnterAction { get; set; }

        public Action<T> OnMouseLeaveAction { get; set; }
    }

    public static class UIElementStyleExtensions
    {
        public static T OnMouseEnter<T, TS>(this T style, Action<TS> action) where T : UIElementStyle<TS> where TS : IUIElement
        {
            style.OnMouseEnterAction = action;
            return style;
        }

        public static T OnMouseLeave<T, TS>(this T style, Action<TS> action) where T : UIElementStyle<TS> where TS : IUIElement
        {
            style.OnMouseLeaveAction = action;
            return style;
        }
    }
}
