using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI
{
    public abstract class Component : VisualNode, IWidgetContainer
    {
        protected sealed override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Render();
        }

        protected abstract VisualNode Render();

    }
}
