using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReactorUI.WPF.Controls.Primitives
{
    public static class FontWeightExtensions
    {
        public static System.Windows.FontWeight ToNativeFontWeight(this FontWeight fontWeight)
        {
            switch (fontWeight)
            {
                case FontWeight.Thin:
                    return System.Windows.FontWeights.Thin;
                case FontWeight.ExtraLight:
                    return System.Windows.FontWeights.ExtraLight;
                case FontWeight.UltraLight:
                    return System.Windows.FontWeights.UltraLight;
                case FontWeight.Light:
                    return System.Windows.FontWeights.Light;
                case FontWeight.Normal:
                    return System.Windows.FontWeights.Normal;
                case FontWeight.Regular:
                    return System.Windows.FontWeights.Regular;
                case FontWeight.Medium:
                    return System.Windows.FontWeights.Medium;
                case FontWeight.DemiBold:
                    return System.Windows.FontWeights.DemiBold;
                case FontWeight.SemiBold:
                    return System.Windows.FontWeights.SemiBold;
                case FontWeight.Bold:
                    return System.Windows.FontWeights.Bold;
                case FontWeight.ExtraBold:
                    return System.Windows.FontWeights.ExtraBold;
                case FontWeight.UltraBold:
                    return System.Windows.FontWeights.UltraBold;
                case FontWeight.Black:
                    return System.Windows.FontWeights.Black;
                case FontWeight.Heavy:
                    return System.Windows.FontWeights.Heavy;
                case FontWeight.ExtraBlack:
                    return System.Windows.FontWeights.ExtraBlack;
                case FontWeight.UltraBlack:
                    return System.Windows.FontWeights.UltraBlack;
                default:
                    throw new ArgumentException();
            }

        }
    }
}
