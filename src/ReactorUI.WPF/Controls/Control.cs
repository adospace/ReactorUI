
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
    internal class Control<T, I> : FrameworkElement<T, I> where T : System.Windows.Controls.Control, new() where I : IControl
    {
        public override void Update(I widget)
        {
            _nativeControl.IsEnabled = widget.IsEnabled;

            if (widget.FontFamily != null)
                _nativeControl.FontFamily = new System.Windows.Media.FontFamily(widget.FontFamily);
            _nativeControl.FontStyle = widget.FontStyle.ToNativeFontStyle();
            _nativeControl.FontStretch = widget.FontStretch.ToNativeFontStyle();
            _nativeControl.FontWeight = widget.FontWeight.ToNativeFontWeight();
            _nativeControl.FontSize = widget.FontSize;

            _nativeControl.Foreground = widget.Foreground?.ToNativeBrush();
            _nativeControl.Background = widget.Background?.ToNativeBrush();
            _nativeControl.BorderBrush = widget.BorderBrush?.ToNativeBrush();
            _nativeControl.BorderThickness = widget.BorderThickness.ToNativeThickness();

            _nativeControl.IsTabStop = widget.IsTabStop;
            _nativeControl.TabIndex = widget.TabIndex;

            _nativeControl.Padding = widget.Padding.ToNativeThickness();

            _nativeControl.HorizontalContentAlignment = (System.Windows.HorizontalAlignment)widget.HorizontalContentAlignment;
            _nativeControl.VerticalContentAlignment = (System.Windows.VerticalAlignment)widget.VerticalContentAlignment;

            base.Update(widget);
        }
    }
}
