using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    internal class TreeViewNode : Control<System.Windows.Controls.TreeViewItem, ITreeViewNode>, INativeControlContainer
    {
        public ObservableCollection<System.Windows.Controls.TreeViewItem> Items { get; } = new ObservableCollection<System.Windows.Controls.TreeViewItem>();

        protected bool HasHeader { get; private set; }

        public void AddChild(object child)
        {
            if (child is System.Windows.Controls.TreeViewItem)
                Items.Add((System.Windows.Controls.TreeViewItem)child);
            else
            {
                _nativeControl.Header = child;
                HasHeader = child != null;
            }
        }

        public void RemoveChild(object child)
        {
            if (child is System.Windows.Controls.TreeViewItem)
                Items.Remove((System.Windows.Controls.TreeViewItem)child);
            else
            {
                _nativeControl.Header = null;
                HasHeader = false;
            }
        }

        public override void DidMount(IWidget widget)
        {
            base.DidMount(widget);

            _nativeControl.SetBinding(System.Windows.Controls.TreeView.ItemsSourceProperty, new System.Windows.Data.Binding("Items")
            {
                Source = this
            });

            _nativeControl.IsExpanded = ((ITreeViewNode)widget).IsExpanded;
        }

        private string _cachedText;
        private string _cachedIconUrl;

        public override void Update(ITreeViewNode widget)
        {
            if (!HasHeader)
            {
                if (widget.IconUrl == null)
                    _nativeControl.Header = widget.Text;
                else
                {
                    if (_cachedText != widget.Text ||
                        _cachedIconUrl != widget.IconUrl)
                    {
                        _cachedText = widget.Text;
                        _cachedIconUrl = widget.IconUrl;

                        var dockPanel = new System.Windows.Controls.DockPanel();
                        var txtElement = new System.Windows.Controls.TextBlock() { Text = _cachedText, Margin = new System.Windows.Thickness(4, 0, 0, 0) };
                        var imgElement = new System.Windows.Controls.Image() { Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(_cachedIconUrl)) };

                        System.Windows.Controls.DockPanel.SetDock(imgElement, System.Windows.Controls.Dock.Left);

                        dockPanel.Children.Add(imgElement);
                        dockPanel.Children.Add(txtElement);

                        _nativeControl.Header = dockPanel;
                    }
                }
            }

            base.Update(widget);
        }

    }
}
