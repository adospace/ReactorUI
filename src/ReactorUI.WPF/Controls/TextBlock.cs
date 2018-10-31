using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using ReactorUI.WPF.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    internal class TextBlock : INativeControl<ITextBlock>
    {
        private System.Windows.Controls.TextBlock _nativeTextBlock = null;

        public string Text { get => _nativeTextBlock.Text; set => _nativeTextBlock.Text = value; }

        public void DidMount(IWidget widget)
        {
            _nativeTextBlock = _nativeTextBlock ?? new System.Windows.Controls.TextBlock();
            widget.ParentAsNativeControlContainer().AddChild(_nativeTextBlock);
        }

        public void WillUnmount(IWidget widget)
        {
            widget.ParentAsNativeControlContainer().RemoveChild(_nativeTextBlock);
        }

        public void Update(ITextBlock widget)
        {
            _nativeTextBlock.Background = widget.Background?.ToNativeBrush();
            _nativeTextBlock.BaselineOffset = widget.BaselineOffset;
            _nativeTextBlock.Text = widget.FontFamily;
            _nativeTextBlock.FontSize = widget.FontSize;
            _nativeTextBlock.FontStretch = widget.FontStretch.ToNativeFontStyle();
            _nativeTextBlock.FontStyle = widget.FontStyle.ToNativeFontStyle();
            _nativeTextBlock.FontWeight = widget.FontWeight.ToNativeFontWeight();
            _nativeTextBlock.Foreground = widget.Foreground?.ToNativeBrush();
            _nativeTextBlock.LineHeight = widget.LineHeight;
            _nativeTextBlock.Padding = widget.Padding.ToNativeThickness();
            _nativeTextBlock.Text = widget.Text;
            _nativeTextBlock.TextAlignment = widget.TextAlignment.ToNativeTextAlignment();
            _nativeTextBlock.TextTrimming = widget.TextTrimming.ToNativeTextTrimming();
            _nativeTextBlock.TextWrapping = widget.TextWrapping.ToNativeTextWrapping();


        }


    }
}
