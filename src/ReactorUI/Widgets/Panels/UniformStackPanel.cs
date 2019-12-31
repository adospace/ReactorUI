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
    public class UniformStackPanel : Panel<IUniformStackPanel, UniformStackPanelStyle>, IUniformStackPanel
    {
        public UniformStackPanel(params VisualNode[] children)
            : base(children)
        {
        }

        public Orientation Orientation { get; set; } = Orientation.Vertical;

        public Size ChildSize { get; set; } = new Size(100, 100);
        //public Vector Offset { get; set; }
    }

    public static class UniformStackPanelExtensions
    {
        //public static UniformStackPanel StackPanel(this IWidgetContainer parent, params VisualNode[] children)
        //{
        //    return new UniformStackPanel(children);
        //}

        public static UniformStackPanel Orientation(this UniformStackPanel panel, Orientation orientation)
        {
            panel.Orientation = orientation;
            return panel;
        }

        //public static UniformStackPanel Offset(this UniformStackPanel panel, Vector offset)
        //{
        //    panel.Offset = offset;
        //    return panel;
        //}

        public static UniformStackPanel ChildSize(this UniformStackPanel panel, Size size)
        {
            panel.ChildSize = size;
            return panel;
        }

        public static UniformStackPanel ChildSize(this UniformStackPanel panel, double width, double height)
        {
            panel.ChildSize = new Size(width, height);
            return panel;
        }
    }
}
