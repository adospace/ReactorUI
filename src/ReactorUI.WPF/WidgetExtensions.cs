using ReactorUI.Widgets;
using ReactorUI.WPF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF
{
    internal static class WidgetExtensions
    {
        public static INativeControlContainer ParentAsNativeControlContainer(this IWidget widget)
        {
            return widget.Parent.NativeControl as INativeControlContainer;
        }
    }
}
