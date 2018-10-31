using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
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

        public void Update(ITextBlock widget)
        {
            _nativeTextBlock.Text = widget.Text;
        }

        public void WillUnmount(IWidget widget)
        {
            widget.ParentAsNativeControlContainer().RemoveChild(_nativeTextBlock);
        }


    }
}
