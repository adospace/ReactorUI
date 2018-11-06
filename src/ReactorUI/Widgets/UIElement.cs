using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class UIElement<T, TS> : Widget<T>, IUIElement, IStyledWidget<TS> where T : class, IUIElement where TS : UIElementStyle<T>
    {
        public bool IsEnabled { get; set; } = true;
        public bool IsHitTestVisible { get; set; } = true;
        public bool IsVisible { get; set; } = true;
        public double Opacity { get; set; } = 1.0;

        public TS Style { get; set; }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield break;
        }

        public Action<IUIElement> OnMouseEnterAction { get; set; }
        public Action<IUIElement> OnMouseLeaveAction { get; set; }

        protected override void OnMount()
        {
            if (Style != null)
                OnApplyStyle();

            base.OnMount();
        }

        protected virtual void OnApplyStyle()
        {

        }

        protected override void OnUnmount()
        {
            if (Style != null)
                OnCancelStyle();

            base.OnUnmount();
        }

        protected virtual void OnCancelStyle()
        {

        }
    }

    public static class UIElementExtentsions
    {
        public static T IsEnabled<T>(this T element, bool isEnabled) where T : class, IUIElement
        {
            element.IsEnabled = isEnabled;
            return element;
        }

        public static T IsHitTestVisible<T>(this T element, bool isHitTestVisible) where T : class, IUIElement
        {
            element.IsHitTestVisible = isHitTestVisible;
            return element;
        }

        public static T IsVisible<T>(this T element, bool isVisible) where T : class, IUIElement
        {
            element.IsVisible = isVisible;
            return element;
        }

        public static T Opacity<T>(this T element, double opacity) where T : class, IUIElement
        {
            element.Opacity = opacity;
            return element;
        }

        public static T Style<T, TS>(this T element, TS style) where T : UIElement<T, TS> where TS : UIElementStyle<T>
        {
            element.Style = style;
            return element;
        }

        public static T OnMouseEnter<T>(this T element, Action<T> action) where T : class, IUIElement
        {
            element.OnMouseEnterAction = (_) => action((T)_);
            return element;
        }

        public static T OnMouseLeave<T>(this T element, Action<T> action) where T : class, IUIElement
        {
            element.OnMouseLeaveAction = (_) => action((T)_);
            return element;
        }
    }
}
