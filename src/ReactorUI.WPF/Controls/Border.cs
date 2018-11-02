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
    internal class Border : FrameworkElement<System.Windows.Controls.Border, IBorder, BorderStyle>, INativeControlContainer
    {
        public void AddChild(object child)
        {
            _nativeControl.Child = (UIElement)child;
        }

        public void RemoveChild(object child)
        {
            _nativeControl.Child = null;
        }


        protected override void OnUpdate()
        {
            _nativeControl.Background = _widget.Background?.ToNativeBrush();
            _nativeControl.BorderBrush = _widget.BorderBrush?.ToNativeBrush();
            _nativeControl.BorderThickness = _widget.BorderThickness.ToNativeThickness();
            _nativeControl.Padding = _widget.Padding.ToNativeThickness();
            _nativeControl.CornerRadius = _widget.CornerRadius.ToNativeCornerRadius();

            base.OnUpdate();
        }
    }
}
