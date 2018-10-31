using ReactorUI.Widgets.Contracts;
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

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield break;
        }

    }

    public static class TextBlockExtensions
    {
        public static TextBlock Text(this TextBlock textBlock, string text)
        {
            textBlock.Text = text;
            return textBlock;
        }
    }
}
