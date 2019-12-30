using ReactorUI.Contracts;
using ReactorUI.Contracts.Panels;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Theme.Modern.Controls
{
    public static class Styles
    {
        public static IButtonStyle ButtonStyle { get; }
            = new ButtonStyle()
                .Background<IButtonStyle, IButton>(Brushes.NeutralWhite)
                .Foreground<IButtonStyle, IButton>(Brushes.NeutralGray160)
                .BorderBrush<IButtonStyle, IButton>(Brushes.NeutralGray110)
                .BorderThickness<IButtonStyle, IButton>(1.0)
                .Padding<IButtonStyle, IButton>(16, 5)
                .OnMouseEnter<IButtonStyle, IButton>(_ => _.Background = Brushes.NeutralGray20)
                .OnMouseLeave<IButtonStyle, IButton>(_ => {
                    if (_.Background == Brushes.NeutralGray20)
                        _.Background = Brushes.NeutralWhite;
                })
                .OnMouseDown<IButtonStyle, IButton>(_ => _.Background = Brushes.NeutralGray30)
                .OnMouseUp<IButtonStyle, IButton>(_ => {
                    if (_.Background == Brushes.NeutralGray30)
                        _.Background = Brushes.NeutralGray20;
                })


            ;


    }
}
