using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Controls
{
    internal class ScrollBar : FrameworkElement<Framework.ScrollBar, IScrollBar>
    {
        protected override void OnUpdate()
        {
            _nativeControl.Background = _widget.Background;
            _nativeControl.FontSize = _widget.FontSize;
            _nativeControl.FontStretch = _widget.FontStretch;
            _nativeControl.FontStyle = _widget.FontStyle;
            _nativeControl.FontWeight = _widget.FontWeight;
            _nativeControl.Foreground = _widget.Foreground;
            _nativeControl.Padding = _widget.Padding;

            _nativeControl.Orientation = _widget.Orientation;
            _nativeControl.Offset = _widget.Offset;
            _nativeControl.Viewport = _widget.Viewport;
            _nativeControl.Extent = _widget.Extent;
            _nativeControl.ThumbBrush = _widget.ThumbBrush;
            base.OnUpdate();
        }
    }

}
