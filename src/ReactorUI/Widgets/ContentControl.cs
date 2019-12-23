using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class ContentControl<T, TS> : Control<T, TS>, IContentControl, IWidgetContainer where T : class, IContentControl where TS : ContentControlStyle<T>
    {
        private readonly VisualNode _content;

        public ContentControl(VisualNode content = null)
        {
            _content = content;
            IsHitTestVisible = content != null;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (_content != null)
                yield return _content;
        }
    }
}
