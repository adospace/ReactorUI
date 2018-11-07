using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System.Collections.Generic;

namespace ReactorUI.Widgets
{
    public class ScrollBar : Control<IScrollBar, ScrollBarStyle>, IScrollBar
    {
        public Orientation Orientation { get; set; }
        public double Offset { get; set; }
        public double Viewport { get; set; }
        public double Extent { get; set; }
        public Brush ThumbBrush { get; set; }
    }

    public static class ScrollBarExtensions
    {
        public static ScrollBar Orientation(this ScrollBar scrollBar, Orientation orientation)
        {
            scrollBar.Orientation = orientation;
            return scrollBar;
        }

        public static ScrollBar Offset(this ScrollBar scrollBar, double offset)
        {
            scrollBar.Offset = offset;
            return scrollBar;
        }

        public static ScrollBar Viewport(this ScrollBar scrollBar, double viewport)
        {
            scrollBar.Viewport = viewport;
            return scrollBar;
        }

        public static ScrollBar Extent(this ScrollBar scrollBar, double extent)
        {
            scrollBar.Extent = extent;
            return scrollBar;
        }

        public static ScrollBar ThumbBrush(this ScrollBar control, Brush brush)
        {
            control.ThumbBrush = brush;
            return control;
        }

        public static ScrollBar ThumbBrush(this ScrollBar control, Color color)
        {
            control.ThumbBrush = new SolidColorBrush(color);
            return control;
        }
    }
}
