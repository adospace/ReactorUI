using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using ReactorUI.Contracts.Panels;
using ReactorUI.Styles.Panels;

namespace ReactorUI.Widgets.Panels
{
    public class StackPanel : Panel<IStackPanel, StackPanelStyle>, IStackPanel
    {
        public StackPanel(params VisualNode[] children)
            : base(children)
        {
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
