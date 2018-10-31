using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
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

        public Brush Background { get => _nativeBorder.Background.ToBrush(); set => _nativeBorder.Background = value.FromBrush(); }

        private readonly VisualNode _child;

        public void AddChild(FrameworkElement child)
        {
            _nativeBorder.Child = child;
        }

        public void InsertChild(FrameworkElement child, int index)
        {
            _nativeBorder.Child = child;
        }

        public void DidMount(IWidget widget)
        {
            _nativeBorder = _nativeBorder ?? new System.Windows.Controls.Border();

            widget.ParentAsNativeControlContainer().AddChild(_nativeBorder);
        }

        public void RemoveChild(FrameworkElement child)
        {
            _nativeBorder.Child = null;
        }

        public void WillUnmount(IWidget widget)
        {
            widget.ParentAsNativeControlContainer().RemoveChild(_nativeBorder);
        }

        public void Update(IBorder widget)
        {
            Background = widget.Background;
        }
    }
}
