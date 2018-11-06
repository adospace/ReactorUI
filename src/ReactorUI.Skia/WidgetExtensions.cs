using ReactorUI.Contracts;
using ReactorUI.Skia.Controls;
using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia
{
    internal static class WidgetExtensions
    {
        public static INativeControlContainer ParentAsNativeControlContainer(this IWidget widget)
        {
            return widget.Parent.NativeControl as INativeControlContainer;
        }
    }
}
