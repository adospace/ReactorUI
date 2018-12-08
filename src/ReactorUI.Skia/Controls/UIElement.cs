using ReactorUI.Widgets;
using ReactorUI.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Styles;

namespace ReactorUI.Skia.Controls
{
    public class UIElement<T, I, TS> : INativeControl
        where T : Framework.UIElement, new()
        where I : IUIElement
        where TS : UIElementStyle<I>
    {
        protected T _nativeControl;

        protected I _widget;

        protected TS Style => ((IStyledWidget<TS>)_widget)?.Style;

        public void DidMount(IWidget widget)
        {
            _widget = (I)widget;
            _nativeControl = _nativeControl ?? new T();

            widget.ParentAsNativeControlContainer().AddChild(widget, _nativeControl);

            OnDidMount();
        }

        protected virtual void OnDidMount()
        {

        }

        public void WillUnmount(IWidget widget)
        {
            OnWillUnmount();

            widget.ParentAsNativeControlContainer().RemoveChild(widget, _nativeControl);
        }

        protected virtual void OnWillUnmount()
        {
            if (_fireOnMouseEnter)
                _nativeControl.MouseEnter -= _nativeControl_MouseEnter;
            if (_fireOnMouseLeave)
                _nativeControl.MouseLeave -= _nativeControl_MouseLeave;
        }

        public void Update(IWidget widget)
        {
            _widget = (I)widget;
            OnUpdate();
        }

        private bool _fireOnMouseEnter;
        private bool _fireOnMouseLeave;

        protected virtual void OnUpdate()
        {
            _nativeControl.IsEnabled = _widget.IsEnabled;
            _nativeControl.IsHitTestVisible = _widget.IsHitTestVisible;
            _nativeControl.IsVisible = _widget.IsVisible;
            _nativeControl.Transform = _widget.Transform;

            System.Diagnostics.Debug.WriteLine("_nativeControl.Opacity -> {0}", _widget.Opacity);
            _nativeControl.Opacity = _widget.Opacity;

            bool shouldFireOnMouseEnter = (_widget.OnMouseEnterAction != null || Style?.OnMouseEnterAction != null);
            bool shouldFireOnMouseLeave = (_widget.OnMouseLeaveAction != null || Style?.OnMouseLeaveAction != null);

            if (!_fireOnMouseEnter && shouldFireOnMouseEnter)
                _nativeControl.MouseEnter += _nativeControl_MouseEnter;
            if (_fireOnMouseEnter && !shouldFireOnMouseEnter)
                _nativeControl.MouseEnter -= _nativeControl_MouseEnter;

            _fireOnMouseEnter = shouldFireOnMouseEnter;

            if (!_fireOnMouseLeave && shouldFireOnMouseLeave)
                _nativeControl.MouseLeave += _nativeControl_MouseLeave;
            if (_fireOnMouseLeave && !shouldFireOnMouseLeave)
                _nativeControl.MouseLeave -= _nativeControl_MouseLeave;

            _fireOnMouseLeave = shouldFireOnMouseLeave;
        }

        private void _nativeControl_MouseEnter(object sender, Framework.Input.MouseEventArgs e)
        {
            Style?.OnMouseEnterAction?.Invoke(_widget);
            _widget.OnMouseEnterAction?.Invoke(_widget);

            OnUpdate();
        }

        private void _nativeControl_MouseLeave(object sender, Framework.Input.MouseEventArgs e)
        {
            Style?.OnMouseLeaveAction?.Invoke(_widget);
            _widget.OnMouseLeaveAction?.Invoke(_widget);

            OnUpdate();
        }

    }
}
