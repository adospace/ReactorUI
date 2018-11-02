
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
    internal class Control<T, I, TS> : FrameworkElement<T, I, TS> 
        where T : System.Windows.Controls.Control, new() 
        where I : IControl
        where TS : ControlStyle<I>
    {
        protected override void OnUpdate()
        {
            if (_widget.FontFamily != null)
                _nativeControl.FontFamily = new System.Windows.Media.FontFamily(_widget.FontFamily);

            _nativeControl.FontStyle = _widget.FontStyle.ToNativeFontStyle();
            _nativeControl.FontStretch = _widget.FontStretch.ToNativeFontStyle();
            _nativeControl.FontWeight = _widget.FontWeight.ToNativeFontWeight();
            _nativeControl.FontSize = _widget.FontSize;

            _nativeControl.Foreground = _widget.Foreground?.ToNativeBrush();
            //System.Diagnostics.Debug.WriteLine($"{_widget}->Background:{_widget.Background?.ToNativeBrush()}");
            _nativeControl.Background = _widget.Background?.ToNativeBrush();
            _nativeControl.BorderBrush = _widget.BorderBrush?.ToNativeBrush();
            _nativeControl.BorderThickness = _widget.BorderThickness.ToNativeThickness();

            _nativeControl.IsTabStop = _widget.IsTabStop;
            _nativeControl.TabIndex = _widget.TabIndex;

            _nativeControl.Padding = _widget.Padding.ToNativeThickness();

            _nativeControl.HorizontalContentAlignment = (System.Windows.HorizontalAlignment)_widget.HorizontalContentAlignment;
            _nativeControl.VerticalContentAlignment = (System.Windows.VerticalAlignment)_widget.VerticalContentAlignment;

            base.OnUpdate();
        }
    }
}
