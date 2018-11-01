using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class Button : ContentControl<IButton>, IButton
    {
        public Button(VisualNode content = null)
            :base(content)
        {
        }

        public Button(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        public Action Click { get; set; }
    }

    public static class ButtonExtensions
    {
        public static Button Button(this IWidgetContainer parent)
        {
            return new Button();
        }

        public static Button Button(this IWidgetContainer parent, string text)
        {
            return new Button(text);
        }

        public static Button Text(this Button button, string text)
        {
            button.Text = text;
            return button;
        }

        public static Button OnClick(this Button button, Action onClick)
        {
            button.Click = onClick;
            return button;
        }
    }
}
