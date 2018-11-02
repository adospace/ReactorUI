using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReactorUI.WPF.Controls.Primitives
{
    public static class FontStyleExtensions
    {
        public static System.Windows.FontStyle ToNativeFontStyle(this FontStyle fontStyle)
        {
            switch (fontStyle)
            {
                case FontStyle.Normal:
                    return System.Windows.FontStyles.Normal;
                case FontStyle.Oblique:
                    return System.Windows.FontStyles.Oblique;
                case FontStyle.Italic:
                    return System.Windows.FontStyles.Italic;
                default:
                    throw new ArgumentException();
            }

        }
    }
}
