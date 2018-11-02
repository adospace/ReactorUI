using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorUI.Widgets
{
    public class TreeView : Control<ITreeView, TreeViewStyle>, ITreeView
    {
        private readonly TreeViewNode[] _nodes;

        public TreeView(params TreeViewNode[] nodes)
        {
            _nodes = nodes;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _nodes.Where(_ => _ != null);
        }

    }

    public static class TreeViewExtensions
    {
        public static TreeView TreeView(this IWidgetContainer parent, params TreeViewNode[] children)
        {
            return new TreeView(children);
        }
    }

}
