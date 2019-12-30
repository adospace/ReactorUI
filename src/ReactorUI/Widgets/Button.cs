using ReactorUI.Contracts;
using ReactorUI.Styles;
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
            HorizontalAlignment = Primitives.HorizontalAlignment.Center;
            VerticalAlignment = Primitives.VerticalAlignment.Center;

            Height = 32;
        }

        public Button(string text)
        {
            Text = text;
            
            IsHitTestVisible = text != null;
            HorizontalAlignment = Primitives.HorizontalAlignment.Center;
            VerticalAlignment = Primitives.VerticalAlignment.Center;

            Height = 32;
        }

        public string Text { get; set; }

        public Action<IButton> OnClickAction { get; set; }

        protected override void OnStyleApplied(ButtonStyle styleToApply)
        {
            base.OnStyleApplied(styleToApply);
        }

    }

    public static class ButtonExtensions
    {
        //public static Button Button(this IWidgetContainer parent)
        //{
        //    return new Button();
        //}

        //public static Button Button(this IWidgetContainer parent, string text)
        //{
        //    return new Button(text);
        //}

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

        //public static Button OnClick(this Button button, Action<Button> onClick)
        //{
        //    button.OnClickAction = (Action<IButton>)onClick;
        //    return button;
        //}

        public static Button Style(this Button button, ButtonStyle style)
        {
            button.SetStyle(style);
            return button;
        }
    }
}
