using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI
{
    public abstract class Component : VisualNode
    {
        protected sealed override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Render();
        }

        protected abstract VisualNode Render();

    }
}
