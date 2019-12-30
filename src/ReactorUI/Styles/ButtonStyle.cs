using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
{
    public class ButtonStyle : ContentControlStyle<IButton>, IButtonStyle
    {
        
    }

    public static class ButtonStyleExtensions
    {
        //public static ButtonStyle OnMouseEnter(this ButtonStyle style, Action<IButton> action)
        //{
        //    style.OnMouseEnterAction = action;
        //    return style;
        //}

        //public static ButtonStyle OnMouseLeave(this ButtonStyle style, Action<IButton> action)
        //{
        //    style.OnMouseLeaveAction = action;
        //    return style;
        //}

        //public static ButtonStyle Background(this ButtonStyle style, Brush brush)
        //{
        //    style.Background = brush;
        //    return style;
        //}

        //public static ButtonStyle Padding(this ButtonStyle control, Thickness thickness)
        //    => control.Padding<ButtonStyle, IButton>(thickness);

        //public static ButtonStyle Padding(this ButtonStyle control, double thickness)
        //    => control.Padding<ButtonStyle, IButton>(thickness);

        //public static ButtonStyle Padding(this ButtonStyle control, double left, double top, double right, double bottom)
        //    => control.Padding<ButtonStyle, IButton>(left, top, right, bottom);
    }

}
