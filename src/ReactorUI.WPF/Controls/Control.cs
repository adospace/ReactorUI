
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
            //if (Style != null)
            //{
            //    if (Style.FontFamily != null)
            //        _nativeControl.FontFamily = new System.Windows.Media.FontFamily(_widget.FontFamily);

            //    _nativeControl.FontStyle = Style.FontStyle.ToNativeFontStyle();
            //    _nativeControl.FontStretch = Style.FontStretch.ToNativeFontStyle();
            //    _nativeControl.FontWeight = Style.FontWeight.ToNativeFontWeight();
            //    _nativeControl.FontSize = Style.FontSize;

            //    _nativeControl.Foreground = Style.Foreground?.ToNativeBrush();
            //    _nativeControl.Background = Style.Background?.ToNativeBrush();
            //    _nativeControl.BorderBrush = Style.BorderBrush?.ToNativeBrush();
            //    _nativeControl.BorderThickness = Style.BorderThickness.ToNativeThickness();

            //    _nativeControl.Padding = Style.Padding.ToNativeThickness();

            //    _nativeControl.HorizontalContentAlignment = (System.Windows.HorizontalAlignment)Style.HorizontalContentAlignment;
            //    _nativeControl.VerticalContentAlignment = (System.Windows.VerticalAlignment)Style.VerticalContentAlignment;
            //}

            if (_widget.FontFamily != null)
                _nativeControl.FontFamily = new System.Windows.Media.FontFamily(_widget.FontFamily);

            _nativeControl.FontStyle = _widget.FontStyle.ToNativeFontStyle();
            _nativeControl.FontStretch = _widget.FontStretch.ToNativeFontStyle();
            _nativeControl.FontWeight = _widget.FontWeight.ToNativeFontWeight();
            _nativeControl.FontSize = _widget.FontSize;

            _nativeControl.Foreground = _widget.Foreground?.ToNativeBrush();
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
