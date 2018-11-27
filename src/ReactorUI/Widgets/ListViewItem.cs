using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorUI.Widgets
{
    public class ListViewItem : Control<IListViewItem, ListViewItemStyle>, IListViewItem
    {
        private readonly VisualNode _header;
        private readonly ListViewItem[] _items;

        public ListViewItem(params ListViewItem[] nodes)
        {
            _items = nodes;
        }

        public ListViewItem(string text, params ListViewItem[] nodes)
        {
            _items = nodes;
            Text = text;
        }

        public ListViewItem(VisualNode header, params ListViewItem[] nodes)
        {
            _header = header;
            _items = nodes;
        }

        public bool IsExpanded { get; set; }
        public string Text { get; set; }
        public string IconUrl { get; set; }
        
        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (_header != null)
                return new VisualNode[] { _header }.Concat(_items.Where(_ => _ != null));

            return _items.Where(_ => _ != null);
        }
    }

    public static class ListViewItemExtensions
    {
        public static ListViewItem ListViewItem(this ListView parent, params ListViewItem[] children)
        {
            return new ListViewItem(children);
        }

        public static ListViewItem ListViewItem(this ListView parent, VisualNode header, params ListViewItem[] children)
        {
            return new ListViewItem(header, children);
        }

        public static ListViewItem Text(this ListViewItem item, string text)
        {
            item.Text = text;
            return item;
        }
    }
}
