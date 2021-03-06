﻿using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.Primitives;
using ReactorUI.WPF.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Styles;

namespace ReactorUI.WPF.Controls
{
    internal class TreeView : Control<System.Windows.Controls.TreeView, ITreeView, TreeViewStyle>, INativeControlContainer
    {
        public ObservableCollection<System.Windows.Controls.TreeViewItem> Items { get; } = new ObservableCollection<System.Windows.Controls.TreeViewItem>();

        public void AddChild(IWidget widget, object child)
        {
            Items.Add((System.Windows.Controls.TreeViewItem)child);
        }

        public void RemoveChild(IWidget widget, object child)
        {
            Items.Remove((System.Windows.Controls.TreeViewItem)child);
        }

        protected override void OnDidMount()
        {
            _nativeControl.SetBinding(System.Windows.Controls.TreeView.ItemsSourceProperty, new System.Windows.Data.Binding("Items")
            {
                Source = this
            });

            base.OnDidMount();
        }

        protected override void OnWillUnmount()
        {
            System.Windows.Data.BindingOperations.ClearBinding(_nativeControl, System.Windows.Controls.TreeView.ItemsSourceProperty);
            base.OnWillUnmount();
        }
    }
}
