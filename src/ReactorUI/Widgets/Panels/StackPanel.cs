using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Panels
{
    public class StackPanel : Panel<IStackPanel, StackPanelStyle>, IStackPanel
    {
        public StackPanel(params VisualNode[] children)
        {
            InternalChildren.AddRange(children);
        }

        public Orientation Orientation { get; set; }
    }

    public static class StackPanelExtensions
    {
        public static StackPanel StackPanel(this IWidgetContainer parent, params VisualNode[] children)
        {
            return new StackPanel(children);
        }

        public static StackPanel Orientation(this StackPanel panel, Orientation orientation)
        {
            panel.Orientation = orientation;
            return panel;
        }
    }
}
