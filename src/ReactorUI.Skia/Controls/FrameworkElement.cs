using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia.Controls
{
    public class FrameworkElement<T, I> : UIElement<T, I>
        where T : Framework.FrameworkElement, new()
        where I : IFrameworkElement
    {
        protected override void OnUpdate()
        {
            _nativeControl.Width = _widget.Width;
            _nativeControl.MinWidth = _widget.MinWidth;
            _nativeControl.MaxHeight = _widget.MaxHeight;
            _nativeControl.Height = _widget.Height;
            _nativeControl.MinHeight = _widget.MinHeight;
            _nativeControl.MaxWidth = _widget.MaxWidth;
            _nativeControl.Margin = _widget.Margin;
            _nativeControl.VerticalAlignment = _widget.VerticalAlignment;
            _nativeControl.HorizontalAlignment = _widget.HorizontalAlignment;
            base.OnUpdate();
        }
    }
}
