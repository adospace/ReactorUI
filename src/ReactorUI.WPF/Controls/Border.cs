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
        public Border(VisualNode child = null)
        {
            _child = child;
        }

        private System.Windows.Controls.Border _nativeBorder = null;

        private readonly VisualNode _child;

        public void AddChild(System.Windows.UIElement child)
        {
            _nativeBorder.Child = child;
        }

        public void InsertChild(System.Windows.UIElement child, int index)
        {
            _nativeBorder.Child = child;
        }


        public void RemoveChild(System.Windows.UIElement child)
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
