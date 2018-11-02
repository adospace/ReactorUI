using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.WPF.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Styles;

namespace ReactorUI.WPF.Controls
{
    internal class TextBlock : FrameworkElement<System.Windows.Controls.TextBlock, ITextBlock, TextBlockStyle>
    {
        protected override void OnUpdate()
        {
            _nativeControl.Background = _widget.Background?.ToNativeBrush();
            _nativeControl.BaselineOffset = _widget.BaselineOffset;
            _nativeControl.Text = _widget.FontFamily;
            _nativeControl.FontSize = _widget.FontSize;
            _nativeControl.FontStretch = _widget.FontStretch.ToNativeFontStyle();
            _nativeControl.FontStyle = _widget.FontStyle.ToNativeFontStyle();
            _nativeControl.FontWeight = _widget.FontWeight.ToNativeFontWeight();
            _nativeControl.Foreground = _widget.Foreground?.ToNativeBrush();
            _nativeControl.LineHeight = _widget.LineHeight;
            _nativeControl.Padding = _widget.Padding.ToNativeThickness();
            _nativeControl.Text = _widget.Text;
            _nativeControl.TextAlignment = _widget.TextAlignment.ToNativeTextAlignment();
            _nativeControl.TextTrimming = _widget.TextTrimming.ToNativeTextTrimming();
            _nativeControl.TextWrapping = _widget.TextWrapping.ToNativeTextWrapping();
            base.OnUpdate();
        }
    }
}
