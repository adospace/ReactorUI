using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using ReactorUI.WPF.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactorUI.WPF.Controls
{
    internal class Border : INativeControl<IBorder>, INativeControlContainer
    {
        private System.Windows.Controls.Border _nativeBorder = null;

        public void AddChild(object child)
        {
            _nativeBorder.Child = (UIElement)child;
        }

        public void RemoveChild(object child)
        {
            _nativeBorder.Child = null;
        }

        public void DidMount(IWidget widget)
        {
            _nativeBorder = _nativeBorder ?? new System.Windows.Controls.Border();

            widget.ParentAsNativeControlContainer().AddChild(_nativeBorder);
        }

        public void WillUnmount(IWidget widget)
        {
            widget.ParentAsNativeControlContainer().RemoveChild(_nativeBorder);
        }

        public void Update(IBorder widget)
        {
            _nativeBorder.Background = widget.Background?.ToNativeBrush();
        }
    }
}
