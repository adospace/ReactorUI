using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    internal class ContentControl<T, I, TS> : Control<T, I, TS>, INativeControlContainer 
        where T : System.Windows.Controls.ContentControl, new() 
        where I : IContentControl 
        where TS : ContentControlStyle<I>
    {
        public ContentControl()
        {
        }

        protected bool HasContent { get; private set; }
        public void AddChild(object child)
        {
            _nativeControl.Content = child;
            HasContent = child != null;
        }

        public void RemoveChild(object child)
        {
            _nativeControl.Content = null;
            HasContent = false;
        }


    }
}
