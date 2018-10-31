using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Primitives
{
    public static class TextWrappingExtensions
    {
        public static System.Windows.TextWrapping ToNativeTextWrapping(this TextWrapping textWrapping)
        {
            switch (textWrapping)
            {
                case TextWrapping.WrapWithOverflow:
                    return System.Windows.TextWrapping.WrapWithOverflow;
                case TextWrapping.NoWrap:
                    return System.Windows.TextWrapping.NoWrap;
                case TextWrapping.Wrap:
                    return System.Windows.TextWrapping.Wrap;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
