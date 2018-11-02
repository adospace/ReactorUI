using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Primitives
{
    public static class ColorExtensions
    {
        public static System.Windows.Media.Color ToNativeColor(this Color color)
        {
            return new System.Windows.Media.Color() { A = color.A, B = color.B, G = color.G, R = color.R };
        }

        public static Color FromNativeColor(this System.Windows.Media.Color color)
        {
            return new Color() { A = color.A, B = color.B, G = color.G, R = color.R };
        }
    }
}
