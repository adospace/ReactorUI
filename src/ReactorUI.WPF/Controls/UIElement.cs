using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using ReactorUI.WPF.Controls.Primitives;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    internal class UIElement<T, I> : INativeControl<I> where T : System.Windows.UIElement, new() where I : IUIElement
    {
        protected T _nativeControl;

        public virtual void DidMount(IWidget widget)
        {
            _nativeControl = _nativeControl ?? new T();

            widget.ParentAsNativeControlContainer().AddChild(_nativeControl);
        }

        public virtual void WillUnmount(IWidget widget)
        {
            widget.ParentAsNativeControlContainer().RemoveChild(_nativeControl);
        }

        public virtual void Update(I widget)
        {

        }
    }
}
