using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class TextBlock : FrameworkElement<ITextBlock, TextBlockStyle>, ITextBlock
    {
        public TextBlock()
        { }

        public TextBlock(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        public FontStyle FontStyle { get; set; } = FontStyle.Normal;
        public FontStretch FontStretch { get; set; } = FontStretch.Normal;
        public FontWeight FontWeight { get; set; } = FontWeight.Normal;
        public double FontSize { get; set; } = 12;

        public string FontFamily { get; set; }
        public double BaselineOffset { get; set; }
        public TextWrapping TextWrapping { get; set; }
        public Brush Background { get; set; }
        public double LineHeight { get; set; } = double.NaN;
        public Thickness Padding { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public TextTrimming TextTrimming { get; set; }
        public Brush Foreground { get; set; } = new SolidColorBrush(Color.FromRGB(0, 0, 0));

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield break;
        }

    }

    public static class TextBlockExtensions
    {
        public static TextBlock TextBlock(this IWidgetContainer parent, string text)
        {
            return new TextBlock(text);
        }

        public static TextBlock Text(this TextBlock textBlock, string text)
        {
            textBlock.Text = text;
            return textBlock;
        }

        public static TextBlock FontWeight(this TextBlock textBlock, FontWeight fontWeight)
        {
            textBlock.FontWeight = fontWeight;
            return textBlock;
        }

        public static TextBlock FontStyle(this TextBlock textBlock, FontStyle fontStyle)
        {
            textBlock.FontStyle = fontStyle;
            return textBlock;
        }

        public static TextBlock FontFamily(this TextBlock textBlock, string fontFamily)
        {
            textBlock.FontFamily = fontFamily;
            return textBlock;
        }

        public static TextBlock FontFamily(this TextBlock textBlock, FontStretch fontStretch)
        {
            textBlock.FontStretch = fontStretch;
            return textBlock;
        }

        public static TextBlock BaselineOffset(this TextBlock textBlock, double baselineOffset)
        {
            textBlock.BaselineOffset = baselineOffset;
            return textBlock;
        }

        public static TextBlock FontSize(this TextBlock textBlock, double fontSize)
        {
            textBlock.FontSize = fontSize;
            return textBlock;
        }

        public static TextBlock TextWrapping(this TextBlock textBlock, TextWrapping textWrapping)
        {
            textBlock.TextWrapping = textWrapping;
            return textBlock;
        }

        public static TextBlock Background(this TextBlock textBlock, Brush background)
        {
            textBlock.Background = background;
            return textBlock;
        }

        public static TextBlock LineHeight(this TextBlock textBlock, double lineHeight)
        {
            textBlock.LineHeight = lineHeight;
            return textBlock;
        }

        public static TextBlock Padding(this TextBlock textBlock, Thickness thickness)
        {
            textBlock.Padding = thickness;
            return textBlock;
        }

        public static TextBlock Padding(this TextBlock textBlock, TextAlignment textAlignment)
        {
            textBlock.TextAlignment = textAlignment;
            return textBlock;
        }

        public static TextBlock TextTrimming(this TextBlock textBlock, TextTrimming textTrimming)
        {
            textBlock.TextTrimming = textTrimming;
            return textBlock;
        }

        public static TextBlock Foreground(this TextBlock textBlock, Brush foreground)
        {
            textBlock.Foreground = foreground;
            return textBlock;
        }
    }
}
