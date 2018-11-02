using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReactorUI.WPF.Controls.Primitives
{
    public static class FontStretchExtensions
    {
        public static System.Windows.FontStretch ToNativeFontStyle(this FontStretch fontStretch)
        {
            switch (fontStretch)
            {
                case FontStretch.UltraCondensed:
                    return System.Windows.FontStretches.UltraCondensed;
                case FontStretch.ExtraCondensed:
                    return System.Windows.FontStretches.ExtraCondensed;
                case FontStretch.Condensed:
                    return System.Windows.FontStretches.Condensed;
                case FontStretch.SemiCondensed:
                    return System.Windows.FontStretches.SemiCondensed;
                case FontStretch.Normal:
                    return System.Windows.FontStretches.Normal;
                case FontStretch.Medium:
                    return System.Windows.FontStretches.Medium;
                case FontStretch.SemiExpanded:
                    return System.Windows.FontStretches.SemiExpanded;
                case FontStretch.Expanded:
                    return System.Windows.FontStretches.Expanded;
                case FontStretch.ExtraExpanded:
                    return System.Windows.FontStretches.ExtraExpanded;
                case FontStretch.UltraExpanded:
                    return System.Windows.FontStretches.UltraExpanded;
                default:
                    throw new ArgumentException();
            }

        }
    }
}
