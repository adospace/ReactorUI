using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactorUI.WPF.Controls
{
    public class ContentControl<T, I> : Control<T, I>, INativeControlContainer where T : System.Windows.Controls.ContentControl, new() where I : IContentControl
    {
        public ContentControl()
        {
        }

        protected bool HasContent { get; private set; }
        public void AddChild(FrameworkElement child)
        {
            _nativeControl.Content = child;
            HasContent = child != null;
        }

        public void InsertChild(FrameworkElement child, int index)
        {
            _nativeControl.Content = child;
            HasContent = child != null;
        }

        public void RemoveChild(FrameworkElement child)
        {
            _nativeControl.Content = null;
            HasContent = false;
        }


    }
}
