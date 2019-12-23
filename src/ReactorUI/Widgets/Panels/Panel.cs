using ReactorUI.Contracts;
using ReactorUI.Contracts.Panels;
using ReactorUI.Styles;
using ReactorUI.Styles.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorUI.Widgets.Panels
{
    public abstract class Panel<T, TS> : FrameworkElement<T, TS>, IWidgetContainer where T : class, IPanel where TS : PanelStyle<T>
    {
        protected Panel(params VisualNode[] children)
        {
            _internalChildren.AddRange(children);
            IsHitTestVisible = _internalChildren.Any();
        }

        private readonly List<VisualNode> _internalChildren = new List<VisualNode>();

        protected void AddChild(VisualNode node)
        {
            _internalChildren.Add(node);
            IsHitTestVisible = _internalChildren.Any();
        }

        protected void RemoveChild(VisualNode node)
        {
            _internalChildren.Remove(node);
            IsHitTestVisible = _internalChildren.Any();
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _internalChildren.Where(_ => _ != null);
        }
    }

    public static class PanelExtensions
    {

    }
}
