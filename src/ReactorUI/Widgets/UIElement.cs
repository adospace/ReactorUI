using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class UIElement<T> : Widget<T>, IUIElement where T : class, IUIElement
    {
        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield break;
        }
    }
}
