using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Widgets;

namespace ReactorUI.WPF.TestApp
{
    public static class Colors
    {
        public static Brush ButtonBackground = new SolidColorBrush(Color.FromARGB(0, 0, 0, 0));
        public static Brush Hover = new SolidColorBrush(Color.FromRGB(255, 0, 0));
    }

    public static class Styles
    {
        public static ButtonStyle CustomButtonStyle { get; } = new ButtonStyle()
            .Padding<ButtonStyle, IButton>(4.0)
            .Background<ButtonStyle, IButton>(Colors.ButtonBackground)
            .OnMouseEnter<ButtonStyle, IButton>(_ => _.Background = Colors.Hover)
            .OnMouseLeave<ButtonStyle, IButton>(_ => _.Background = Colors.ButtonBackground)
            ;
    }
}
