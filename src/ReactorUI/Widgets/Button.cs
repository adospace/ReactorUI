using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class Button : ContentControl<IButton, ButtonStyle>, IButton
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

        public Action<IButton> OnClickAction { get; set; }

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
            button.OnClickAction = _ => onClick();
            return button;
        }

        public static Button OnClick(this Button button, Action<Button> onClick)
        {
            button.OnClickAction = (Action<IButton>)onClick;
            return button;
        }

        public static Button Style(this Button button, ButtonStyle style)
        {
            button.Style = style;
            return button;
        }
    }
}
