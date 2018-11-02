using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorUI.Widgets
{
    public class TreeViewNode : Control<ITreeViewNode, TreeViewNodeStyle>, ITreeViewNode
    {
        private readonly VisualNode _header;
        private readonly TreeViewNode[] _nodes;

        public TreeViewNode(params TreeViewNode[] nodes)
        {
            _nodes = nodes;
        }

        public TreeViewNode(string text, params TreeViewNode[] nodes)
        {
            _nodes = nodes;
            Text = text;
        }

        public TreeViewNode(string text, string iconUrl, params TreeViewNode[] nodes)
        {
            _nodes = nodes;
            Text = text;
            IconUrl = iconUrl;
        }

        public TreeViewNode(VisualNode header, params TreeViewNode[] nodes)
        {
            _header = header;
            _nodes = nodes;
        }

        public bool IsExpanded { get; set; }
        public string Text { get; set; }
        public string IconUrl { get; set; }
        
        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (_header != null)
                return new VisualNode[] { _header }.Concat(_nodes.Where(_ => _ != null));

            return _nodes.Where(_ => _ != null);
        }
    }

    public static class TreeViewNodeExtensions
    {
        public static TreeViewNode TreeViewNode(this TreeView parent, params TreeViewNode[] children)
        {
            return new TreeViewNode(children);
        }

        public static TreeViewNode TreeViewNode(this TreeView parent, VisualNode header, params TreeViewNode[] children)
        {
            return new TreeViewNode(header, children);
        }

        public static TreeViewNode TreeViewNode(this TreeViewNode parent, params TreeViewNode[] children)
        {
            return new TreeViewNode(children);
        }

        public static TreeViewNode TreeViewNode(this TreeViewNode parent, VisualNode header, params TreeViewNode[] children)
        {
            return new TreeViewNode(header, children);
        }

        public static TreeViewNode IsExpanded(this TreeViewNode node, bool isExpended)
        {
            node.IsExpanded = isExpended;
            return node;
        }

        public static TreeViewNode Text(this TreeViewNode node, string text)
        {
            node.Text = text;
            return node;
        }
    }
}
