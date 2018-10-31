using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class TextBlock : Widget<ITextBlock>, ITextBlock
    {
        public TextBlock()
        { }

        public TextBlock(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public FontWeight FontWeight { get; set; }
        public FontStyle FontStyle { get; set; }
        public string FontFamily { get; set; }

        public FontStretch FontStretch { get; set; }
        public double BaselineOffset { get; set; }
        public double FontSize { get; set; }
        public TextWrapping TextWrapping { get; set; }
        public Brush Background { get; set; }
        public double LineHeight { get; set; }
        public Thickness Padding { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public TextTrimming TextTrimming { get; set; }
        public Brush Foreground { get; set; }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield break;
        }

    }

    public static class TextBlockExtensions
    {
        public static TextBlock TextBlock(this VisualNode parent, string text)
        {
            return new TextBlock(text);
        }

        public static TextBlock Text(this TextBlock textBlock, string text)
        {
            textBlock.Text = text;
            return textBlock;
        }
    }
}
