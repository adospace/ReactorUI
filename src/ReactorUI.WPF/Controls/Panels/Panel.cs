using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;

namespace ReactorUI.WPF.Controls.Panels
{
    internal abstract class Panel<T, I> : INativeControl<I>, INativeControlContainer, IPanel where T : System.Windows.Controls.Panel, new()
    {
        protected T NativePanel { get; private set; }

        protected Panel()
        {
        }


        public void AddChild(object child)
        {
            NativePanel.Children.Add((UIElement)child);
        }

        public void RemoveChild(object child)
        {
            NativePanel.Children.Remove((UIElement)child);
        }

        public void DidMount(IWidget widget)
        {
            NativePanel = NativePanel ?? new T();
            widget.ParentAsNativeControlContainer().AddChild(NativePanel);
        }

        public void WillUnmount(IWidget widget)
        {
            widget.ParentAsNativeControlContainer().RemoveChild(NativePanel);
        }

        public virtual void Update(I widget)
        {
            
        }
    }
}
