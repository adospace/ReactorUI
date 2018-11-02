using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Primitives
{
    public static class CornerRadiusExtensions
    {
        public static System.Windows.CornerRadius ToNativeCornerRadius(this CornerRadius cornerRadius)
        {
            return new System.Windows.CornerRadius(cornerRadius.TopLeft, cornerRadius.TopRight, cornerRadius.BottomRight, cornerRadius.BottomLeft);
        }

    }
}
