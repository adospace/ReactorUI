
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
    public class Control<T, I, TS> : FrameworkElement<T, I, TS> 
        where T : Framework.Control, new() 
        where I : IControl
        where TS : ControlStyle<I>
    {
        protected override void OnUpdate()
        {
            if (Style != null)
            {
                _nativeControl.FontFamily = _widget.FontFamily;

                _nativeControl.FontStyle = Style.FontStyle;
                _nativeControl.FontStretch = Style.FontStretch;
                _nativeControl.FontWeight = Style.FontWeight;
                _nativeControl.FontSize = Style.FontSize;

                _nativeControl.Foreground = Style.Foreground;
                _nativeControl.Background = Style.Background;
                _nativeControl.BorderBrush = Style.BorderBrush;
                _nativeControl.BorderThickness = Style.BorderThickness;

                _nativeControl.Padding = Style.Padding;

                //_nativeControl.HorizontalContentAlignment = Style.HorizontalContentAlignment;
                //_nativeControl.VerticalContentAlignment = Style.VerticalContentAlignment;
            }

            _nativeControl.FontFamily = _widget.FontFamily;

            _nativeControl.FontStyle = _widget.FontStyle;
            _nativeControl.FontStretch = _widget.FontStretch;
            _nativeControl.FontWeight = _widget.FontWeight;
            _nativeControl.FontSize = _widget.FontSize;

            _nativeControl.Foreground = _widget.Foreground;
            _nativeControl.Background = _widget.Background;
            _nativeControl.BorderBrush = _widget.BorderBrush;
            _nativeControl.BorderThickness = _widget.BorderThickness;

            _nativeControl.IsTabStop = _widget.IsTabStop;
            _nativeControl.TabIndex = _widget.TabIndex;

            _nativeControl.Padding = _widget.Padding;

            //_nativeControl.HorizontalContentAlignment = _widget.HorizontalContentAlignment;
            //_nativeControl.VerticalContentAlignment = _widget.VerticalContentAlignment;

            base.OnUpdate();
        }
    }
}
