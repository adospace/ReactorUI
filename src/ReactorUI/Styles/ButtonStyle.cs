using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
{
    public class ButtonStyle : ContentControlStyle<IButton>
    {
    }

    public static class ButtonStyleExtensions
    {
        public static ButtonStyle OnMouseEnter(this ButtonStyle style, Action<IButton> action)
        {
            style.OnMouseEnterAction = action;
            return style;
        }

        public static ButtonStyle OnMouseLeave(this ButtonStyle style, Action<IButton> action)
        {
            style.OnMouseLeaveAction = action;
            return style;
        }

        public static ButtonStyle Background(this ButtonStyle style, Brush brush)
        {
            style.Background = brush;
            return style;
        }

    }

}
