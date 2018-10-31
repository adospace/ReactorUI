using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Primitives
{
    public static class TextAlignmentExtensions
    {
        public static System.Windows.TextAlignment ToNativeTextAlignment(this TextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case TextAlignment.Left:
                    return System.Windows.TextAlignment.Left;
                case TextAlignment.Right:
                    return System.Windows.TextAlignment.Right;
                case TextAlignment.Center:
                    return System.Windows.TextAlignment.Center;
                case TextAlignment.Justify:
                    return System.Windows.TextAlignment.Justify;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
