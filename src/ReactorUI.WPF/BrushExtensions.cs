using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF
{
    public static class BrushExtensions
    {
        public static System.Windows.Media.Brush FromBrush(this Brush brush)
        {
            if (brush is SolidColorBrush)
                return ((SolidColorBrush)brush).FromBrush();

            throw new InvalidOperationException();
        }

        public static System.Windows.Media.SolidColorBrush FromBrush(this SolidColorBrush brush)
        {
            var nativeBrush = new System.Windows.Media.SolidColorBrush(brush.Color.ToColor());
            nativeBrush.Freeze();
            return nativeBrush;
        }


        public static Brush ToBrush(this System.Windows.Media.Brush brush)
        {
            if (brush is System.Windows.Media.SolidColorBrush)
                return ((System.Windows.Media.SolidColorBrush)brush).ToBrush();

            throw new InvalidOperationException();
        }

        public static SolidColorBrush ToBrush(this System.Windows.Media.SolidColorBrush brush)
        {
            return new SolidColorBrush(brush.Color.FromColor());
        }

    }
}
