using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    public class Control<T, I> : INativeControl<I> where T : System.Windows.Controls.Control, new() where I : IControl
    {
        protected T _nativeControl = null;

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
            _nativeControl.Background = widget.Background?.FromBrush();
            _nativeControl.IsEnabled = widget.IsEnabled;
        }
    }
}
