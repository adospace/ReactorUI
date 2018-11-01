using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Panels
{
    public abstract class Panel<T> : Widget<T>, IWidgetContainer where T : class
    {
        internal List<VisualNode> InternalChildren { get; } = new List<VisualNode>();

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return InternalChildren;
        }
    }

    public static class PanelExtensions
    {

    }
}
