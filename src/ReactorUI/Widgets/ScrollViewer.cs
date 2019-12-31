using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class ScrollViewer : FrameworkElement<IScrollViewer, ScrollViewerStyle>, IScrollViewer
    {
        private readonly VisualNode _child;

        public ScrollViewer(VisualNode child = null)
        {
            _child = child;
            IsHitTestVisible = child != null;
        }

        public ScrollMode VerticalScrollMode { get; set; } = ScrollMode.Auto;
        public ScrollMode HorizontalScrollMode { get; set; } = ScrollMode.Disabled;

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (_child != null)
                yield return _child;
        }
    }

    public static class ScrollViewerExtensions
    {
        public static ScrollViewer VerticalScrollMode(this ScrollViewer scrollViewer, ScrollMode mode)
        {
            scrollViewer.VerticalScrollMode = mode;
            return scrollViewer;
        }

        public static ScrollViewer HorizontalScrollMode(this ScrollViewer scrollViewer, ScrollMode mode)
        {
            scrollViewer.HorizontalScrollMode = mode;
            return scrollViewer;
        }
    }
}
