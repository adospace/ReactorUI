using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Primitives
{
    public static class TextTrimmingExtensions
    {
        public static System.Windows.TextTrimming ToNativeTextTrimming(this TextTrimming textTrimming)
        {
            switch (textTrimming)
            {
                case TextTrimming.None:
                    return System.Windows.TextTrimming.None;
                case TextTrimming.CharacterEllipsis:
                    return System.Windows.TextTrimming.CharacterEllipsis;
                case TextTrimming.WordEllipsis:
                    return System.Windows.TextTrimming.WordEllipsis;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
