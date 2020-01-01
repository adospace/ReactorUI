using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Controls
{
    public class ScrollViewer : FrameworkElement<Framework.ScrollViewer, IScrollViewer>, INativeControlContainer
    {
        public void AddChild(IWidget widget, Framework.UIElement child)
        {
            _nativeControl.Child = (Framework.UIElement)child;
        }

        public void RemoveChild(IWidget widget, Framework.UIElement child)
        {
            _nativeControl.Child = null;
        }

        protected override void OnUpdate()
        {
            _nativeControl.HorizontalScrollMode = _widget.HorizontalScrollMode;
            _nativeControl.VerticalScrollMode = _widget.VerticalScrollMode;

            base.OnUpdate();
        }

        protected override void OnAnimate()
        {
            _nativeControl.Animate();

            base.OnAnimate();
        }
    }
}
