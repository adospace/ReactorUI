using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReactorUI.Styles;

namespace ReactorUI.Skia.Controls
{
    public class Border : FrameworkElement<Framework.Border, IBorder, BorderStyle>, INativeControlContainer
    {
        public void AddChild(IWidget widget, Framework.UIElement child)
        {
            _nativeControl.Child = (Framework.UIElement) child;
        }

        public void RemoveChild(IWidget widget, Framework.UIElement child)
        {
            _nativeControl.Child = null;
        }


        protected override void OnUpdate()
        {
            _nativeControl.Background = _widget.Background;
            _nativeControl.BorderBrush = _widget.BorderBrush;
            _nativeControl.BorderThickness = _widget.BorderThickness;
            _nativeControl.Padding = _widget.Padding;
            _nativeControl.CornerRadius = _widget.CornerRadius;

            base.OnUpdate();
        }
    }
}
