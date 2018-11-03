using ReactorUI.Contracts;
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

        //public static INativeControlContainer ParentAsNativeControlContainer(this IWidget widget)
        //{
        //    var node = (VisualNode)widget;
        //    var parent = node.Parent;

        //    while (parent != null && (!(parent is IWidget)))
        //        parent = parent.Parent;

        //    if (parent == null ||
        //        (!(parent is IWidget)))
        //    {
        //        throw new InvalidOperationException();
        //    }

        //    return ((IWidget)parent).NativeControl as INativeControlContainer;
        //}
    }
}
