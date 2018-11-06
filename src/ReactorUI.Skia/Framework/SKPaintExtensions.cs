using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    internal static class SKPaintExtensions
    {
        public static SKPaint ApplyBrush(this SKPaint paint, Brush brush)
        {
            if (brush is SolidColorBrush solidBrush)
                return paint.ApplyBrush(solidBrush);

            return paint;
        }

        public static SKPaint ApplyBrush(this SKPaint paint, SolidColorBrush brush)
        {
            paint.Color = new SKColor(brush.Color.R, brush.Color.G, brush.Color.B, brush.Color.A);
            return paint;
        }

        public static SKPaint ApplyFont(this SKPaint paint, string fontfamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight)
        {
            paint.TextSize = (float)fontSize;

            paint.Typeface = SKTypeface.FromFamilyName(fontfamily, ConvertFontStyle(fontWeight), ConvertFontStyle(fontStretch), ConvertFontStyle(fontStyle));

            return paint;
        }

        public static SKFontStyleWeight ConvertFontStyle(FontWeight fontWeight)
        {
            switch (fontWeight)
            {
                case FontWeight.Thin:
                    return SKFontStyleWeight.Thin;
                case FontWeight.ExtraLight:
                    return SKFontStyleWeight.ExtraLight;
                case FontWeight.UltraLight:
                    throw new NotSupportedException();
                case FontWeight.Light:
                    return SKFontStyleWeight.Light;
                case FontWeight.Normal:
                    return SKFontStyleWeight.Normal;
                case FontWeight.Regular:
                    throw new NotSupportedException();
                case FontWeight.Medium:
                    return SKFontStyleWeight.Medium;
                case FontWeight.DemiBold:
                    throw new NotSupportedException();
                case FontWeight.SemiBold:
                    return SKFontStyleWeight.SemiBold;
                case FontWeight.Bold:
                    return SKFontStyleWeight.Bold;
                case FontWeight.ExtraBold:
                    return SKFontStyleWeight.ExtraBold;
                case FontWeight.UltraBold:
                    throw new NotSupportedException();
                case FontWeight.Black:
                    return SKFontStyleWeight.Black;
                case FontWeight.Heavy:
                    throw new NotSupportedException();
                case FontWeight.ExtraBlack:
                    return SKFontStyleWeight.ExtraBlack;
                case FontWeight.UltraBlack:
                    throw new NotSupportedException();
                default:
                    throw new NotSupportedException();
            }
        }

        public static SKFontStyleWidth ConvertFontStyle(FontStretch fontStretch)
        {
            switch (fontStretch)
            {
                case FontStretch.UltraCondensed:
                    return SKFontStyleWidth.UltraCondensed;
                case FontStretch.ExtraCondensed:
                    return SKFontStyleWidth.ExtraCondensed;
                case FontStretch.Condensed:
                    return SKFontStyleWidth.Condensed;
                case FontStretch.SemiCondensed:
                    return SKFontStyleWidth.SemiCondensed;
                case FontStretch.Normal:
                    return SKFontStyleWidth.Normal;
                case FontStretch.Medium:
                    throw new NotSupportedException();
                case FontStretch.SemiExpanded:
                    return SKFontStyleWidth.SemiExpanded;
                case FontStretch.Expanded:
                    return SKFontStyleWidth.Expanded;
                case FontStretch.ExtraExpanded:
                    return SKFontStyleWidth.ExtraExpanded;
                case FontStretch.UltraExpanded:
                    return SKFontStyleWidth.UltraExpanded;
                default:
                    throw new NotSupportedException();
            }
        }

        public static SKFontStyleSlant ConvertFontStyle(FontStyle fontStyle)
        {
            switch (fontStyle)
            {
                case FontStyle.Normal:
                    return SKFontStyleSlant.Upright;
                case FontStyle.Oblique:
                    return SKFontStyleSlant.Oblique;
                case FontStyle.Italic:
                    return SKFontStyleSlant.Italic;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
