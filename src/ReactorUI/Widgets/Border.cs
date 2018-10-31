using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using System.Collections.Generic;

namespace ReactorUI.Widgets
{
    public class Border : Widget<IBorder>, IBorder
    {
        public Border(VisualNode child = null)
        {
            Child = child;
        }

        public Brush Background { get; set; }

        public VisualNode Child { get; set; }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (Child != null)
                yield return Child;
        }
    }

}
