using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    internal class TextBlock : FrameworkElement
    {
        #region Public Properties
        string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                }
            }
        }
        TextAlignment _textAlignment;
        public TextAlignment TextAlignment
        {
            get => _textAlignment;
            set
            {
                if (_textAlignment != value)
                {
                    _textAlignment = value;
                }
            }
        }
        TextTrimming _textTrimming;
        public TextTrimming TextTrimming
        {
            get => _textTrimming;
            set
            {
                if (_textTrimming != value)
                {
                    _textTrimming = value;
                }
            }
        }
        TextWrapping _textWrapping;
        public TextWrapping TextWrapping
        {
            get => _textWrapping;
            set
            {
                if (_textWrapping != value)
                {
                    _textWrapping = value;
                }
            }
        }
        double _lineHeight;
        public double LineHeight
        {
            get => _lineHeight;
            set
            {
                if (_lineHeight != value)
                {
                    _lineHeight = value;
                }
            }
        }
        double _baselineOffset;
        public double BaselineOffset
        {
            get => _baselineOffset;
            set
            {
                if (_baselineOffset != value)
                {
                    _baselineOffset = value;
                }
            }
        }
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
        #endregion


        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Text == null)
                return new Size();

            var paint = new SKPaint();

            paint.ApplyFont(FontFamily, FontSize, FontStyle, FontStretch, FontWeight);

            var bounds = new SKRect();
            paint.MeasureText(Text, ref bounds);

            return new Size(bounds.Width, bounds.Height);
        }
        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            return finalSize;
        }
        #endregion


        #region Render Pass
        protected override void RenderOverride(RenderContext context)
        {
            if (Text != null)
            {
                var paint = new SKPaint();

                paint.IsAntialias = true;
                paint.ApplyBrush(Foreground);
                paint.ApplyFont(FontFamily, FontSize, FontStyle, FontStretch, FontWeight);

                context.Canvas.DrawText(Text, 0.0f, (float)DesiredSize.Height, paint);
            }

            base.RenderOverride(context);
        }

        #endregion
    }
}
