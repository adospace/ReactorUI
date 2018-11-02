using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System.Collections.Generic;

namespace ReactorUI.Widgets
{
    public class Border : FrameworkElement<IBorder, BorderStyle>, IBorder
    {
        private readonly VisualNode _child;

        public Border(VisualNode child = null)
        {
            _child = child;
        }

        public Thickness BorderThickness { get; set; }
        public Thickness Padding { get; set; }
        public CornerRadius CornerRadius { get; set; }
        public Brush BorderBrush { get; set; }
        public Brush Background { get; set; }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (_child != null)
                yield return _child;
        }
    }

    public static class BorderExtensions
    {
        public static Border Border(this IWidgetContainer parent, VisualNode child = null)
        {
            return new Border(child);
        }

        public static Border BorderThickness(this Border border, Thickness borderThickness)
        {
            border.BorderThickness = borderThickness;
            return border;
        }

        public static Border Padding(this Border border, Thickness padding)
        {
            border.Padding = padding;
            return border;
        }

        public static Border CornerRadius(this Border border, CornerRadius cornerRadius)
        {
            border.CornerRadius = cornerRadius;
            return border;
        }

        public static Border BorderBrush(this Border border, Brush brush)
        {
            border.BorderBrush = brush;
            return border;
        }

        public static Border Background(this Border border, Brush brush)
        {
            border.Background = brush;
            return border;
        }
    }
}
