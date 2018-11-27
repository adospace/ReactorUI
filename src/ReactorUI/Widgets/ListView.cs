using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorUI.Widgets
{
    public class ListView : Control<IListView, ListViewStyle>, IListView
    {
        private readonly ListViewItem[] _nodes;

        public ListView(params ListViewItem[] nodes)
        {
            _nodes = nodes;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _nodes.Where(_ => _ != null);
        }

    }

    public static class ListViewExtensions
    {
        //public static ListView ListView(this IWidgetContainer parent, params ListViewItem[] children)
        //{
        //    return new ListView(children);
        //}
    }

}
