using ReactorUI.Widgets;
using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Styles;

namespace ReactorUI.Skia.Controls
{
    public class TextBlock : FrameworkElement<Framework.TextBlock, ITextBlock, TextBlockStyle>
    {
        protected override void OnUpdate()
        {
            _nativeControl.Background = _widget.Background;
            _nativeControl.BaselineOffset = _widget.BaselineOffset;
            _nativeControl.FontFamily = _widget.FontFamily;
            _nativeControl.FontSize = _widget.FontSize;
            _nativeControl.FontStretch = _widget.FontStretch;
            _nativeControl.FontStyle = _widget.FontStyle;
            _nativeControl.FontWeight = _widget.FontWeight;
            _nativeControl.Foreground = _widget.Foreground;
            _nativeControl.LineHeight = _widget.LineHeight;
            _nativeControl.Padding = _widget.Padding;
            _nativeControl.Text = _widget.Text;
            _nativeControl.TextAlignment = _widget.TextAlignment;
            _nativeControl.TextTrimming = _widget.TextTrimming;
            _nativeControl.TextWrapping = _widget.TextWrapping;
            base.OnUpdate();
        }
    }
}
