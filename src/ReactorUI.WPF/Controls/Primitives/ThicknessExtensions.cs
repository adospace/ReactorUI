using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Primitives
{
    public static class ThicknessExtensions
    {
        public static System.Windows.Thickness ToNativeThickness(this Thickness thickness)
        {
            return new System.Windows.Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
        }

        public static Thickness FromNativeThickness(this System.Windows.Thickness thickness)
        {
            return new Thickness(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
        }
    }
}
