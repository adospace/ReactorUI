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
    internal class TreeViewNode : Control<System.Windows.Controls.TreeViewItem, ITreeViewNode, TreeViewNodeStyle>, INativeControlContainer
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

        protected override void OnDidMount()
        {
            _nativeControl.SetBinding(System.Windows.Controls.TreeView.ItemsSourceProperty, new System.Windows.Data.Binding("Items")
            {
                Source = this
            });

            _nativeControl.IsExpanded = ((ITreeViewNode)_widget).IsExpanded;
            base.OnDidMount();
        }

        protected override void OnWillUnmount()
        {
            System.Windows.Data.BindingOperations.ClearBinding(_nativeControl, System.Windows.Controls.TreeView.ItemsSourceProperty);
            base.OnWillUnmount();
        }
               
        private string _cachedText;
        private string _cachedIconUrl;

        protected override void OnUpdate()
        {
            if (!HasHeader)
            {
                if (_widget.IconUrl == null)
                    _nativeControl.Header = _widget.Text;
                else
                {
                    if (_cachedText != _widget.Text ||
                        _cachedIconUrl != _widget.IconUrl)
                    {
                        _cachedText = _widget.Text;
                        _cachedIconUrl = _widget.IconUrl;

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
            base.OnUpdate();
        }


    }
}
