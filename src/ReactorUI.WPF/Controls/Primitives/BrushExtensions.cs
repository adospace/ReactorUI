using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Primitives
{
    public static class BrushExtensions
    {
        public static System.Windows.Media.Brush ToNativeBrush(this Brush brush)
        {
            if (brush is SolidColorBrush)
                return ((SolidColorBrush)brush).ToNativeBrush();

            throw new InvalidOperationException();
        }

        public static System.Windows.Media.SolidColorBrush ToNativeBrush(this SolidColorBrush brush)
        {
            var nativeBrush = new System.Windows.Media.SolidColorBrush(brush.Color.ToNativeColor());
            nativeBrush.Freeze();
            return nativeBrush;
        }


        public static Brush FromNativeBrush(this System.Windows.Media.Brush brush)
        {
            if (brush is System.Windows.Media.SolidColorBrush)
                return ((System.Windows.Media.SolidColorBrush)brush).FromNativeBrush();

            throw new InvalidOperationException();
        }

        public static SolidColorBrush FromNativeBrush(this System.Windows.Media.SolidColorBrush brush)
        {
            return new SolidColorBrush(brush.Color.FromNativeColor());
        }

    }
}
