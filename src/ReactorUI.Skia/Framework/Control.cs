using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public class Control : FrameworkElement
    {
        #region Public Properties
        string _fontFamily;
        public string FontFamily
        {
            get => _fontFamily;
            set
            {
                if (_fontFamily != value)
                {
                    _fontFamily = value;
                }
            }
        }
        FontStyle _fontStyle;
        public FontStyle FontStyle
        {
            get => _fontStyle;
            set
            {
                if (_fontStyle != value)
                {
                    _fontStyle = value;
                }
            }
        }
        FontStretch _fontStretch;
        public FontStretch FontStretch
        {
            get => _fontStretch;
            set
            {
                if (_fontStretch != value)
                {
                    _fontStretch = value;
                }
            }
        }
        FontWeight _fontWeight;
        public FontWeight FontWeight
        {
            get => _fontWeight;
            set
            {
                if (_fontWeight != value)
                {
                    _fontWeight = value;
                }
            }
        }
        double _fontSize;
        public double FontSize
        {
            get => _fontSize;
            set
            {
                if (_fontSize != value)
                {
                    _fontSize = value;
                }
            }
        }
        Brush _foreground;
        public Brush Foreground
        {
            get => _foreground;
            set
            {
                if (_foreground != value)
                {
                    _foreground = value;
                }
            }
        }
        Brush _background;
        public Brush Background
        {
            get => _background;
            set
            {
                if (_background != value)
                {
                    _background = value;
                    Invalidate(InvalidateMode.Render);
                }
            }
        }
        Brush _borderBrush;
        public Brush BorderBrush
        {
            get => _borderBrush;
            set
            {
                if (_borderBrush != value)
                {
                    _borderBrush = value;
                }
            }
        }
        Thickness _borderThickness;
        public Thickness BorderThickness
        {
            get => _borderThickness;
            set
            {
                if (!_borderThickness.IsCloseTo(value))
                {
                    _borderThickness = value;
                }
            }
        }
        Thickness _padding;
        public Thickness Padding
        {
            get => _padding;
            set
            {
                if (!_padding.IsCloseTo(value))
                {
                    _padding = value;
                }
            }
        }
        //HorizontalAlignment _horizontalContentAlignment;
        //public HorizontalAlignment HorizontalContentAlignment
        //{
        //    get => _horizontalContentAlignment;
        //    set
        //    {
        //        if (_horizontalContentAlignment != value)
        //        {
        //            _horizontalContentAlignment = value;
        //        }
        //    }
        //}
        //VerticalAlignment _verticalContentAlignment;
        //public VerticalAlignment VerticalContentAlignment
        //{
        //    get => _verticalContentAlignment;
        //    set
        //    {
        //        if (_verticalContentAlignment != value)
        //        {
        //            _verticalContentAlignment = value;
        //        }
        //    }
        //}
        bool _isTabStop;
        public bool IsTabStop
        {
            get => _isTabStop;
            set
            {
                if (_isTabStop != value)
                {
                    _isTabStop = value;
                }
            }
        }
        int _tabIndex;
        public int TabIndex
        {
            get => _tabIndex;
            set
            {
                if (_tabIndex != value)
                {
                    _tabIndex = value;
                }
            }
        }
        #endregion

        #region Measure Pass
        #endregion

        #region Arrange Pass
        #endregion

        #region Render Pass
        protected override void RenderOverride(RenderContext context)
        {
            base.RenderOverride(context);

            var finalWidth = RenderSize.Width - (BorderThickness.Left + BorderThickness.Right);
            var finalHeight = RenderSize.Height - (BorderThickness.Top + BorderThickness.Bottom);

            if (Background != null)
            {
                context.Canvas.DrawRect(
                    0.0f, 0.0f, (float)finalWidth, (float)finalHeight,
                    new SkiaSharp.SKPaint()
                    {
                    }.ApplyBrush(Background, Opacity));
            }

            if (BorderBrush != null)
            {
                if (BorderThickness.IsUniformLength)
                {
                    if (BorderThickness.UniformLength > 0.0)
                    {
                        context.Canvas.DrawRect(
                            0.0f, 0.0f, (float)finalWidth, (float)finalHeight,
                            new SkiaSharp.SKPaint()
                            {
                                IsStroke = true
                            }.ApplyBrush(BorderBrush, Opacity));
                    }
                }
            }

        }
        #endregion
    }
}
