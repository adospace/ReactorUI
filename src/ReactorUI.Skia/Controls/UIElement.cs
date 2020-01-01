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
    public class UIElement<T, I> : INativeControl
        where T : Framework.UIElement, new()
        where I : IUIElement
    {
        protected T _nativeControl;

        protected I _widget;

        public void DidMount(IWidget widget)
        {
            _widget = (I)widget;
            _nativeControl ??= CreateNativeControl();

            widget.ParentAsNativeControlContainer().AddChild(widget, _nativeControl);

            OnDidMount();
        }

        protected virtual T CreateNativeControl() => new T();

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
            if (_fireOnMouseDown)
                _nativeControl.MouseDown -= _nativeControl_MouseDown;
            if (_fireOnMouseUp)
                _nativeControl.MouseUp -= _nativeControl_MouseUp;
        }

        public void Update(IWidget widget)
        {
            _widget = (I)widget;
            OnUpdate();
        }

        public void Animate()
        {
            OnAnimate();
        }

        private bool _fireOnMouseEnter;
        private bool _fireOnMouseLeave;
        private bool _fireOnMouseDown;
        private bool _fireOnMouseUp;

        protected virtual void OnUpdate()
        {
            _nativeControl.IsEnabled = _widget.IsEnabled;
            _nativeControl.IsHitTestVisible = _widget.IsHitTestVisible;
            _nativeControl.IsVisible = _widget.IsVisible;
            _nativeControl.Transform = _widget.Transform;

            _nativeControl.Opacity = _widget.Opacity;

            bool shouldFireOnMouseEnter = (_widget.OnMouseEnterAction != null);
            bool shouldFireOnMouseLeave = (_widget.OnMouseLeaveAction != null);
            bool shouldFireOnMouseDown = (_widget.OnMouseDownAction != null);
            bool shouldFireOnMouseUp = (_widget.OnMouseUpAction != null);

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

            if (!_fireOnMouseDown && shouldFireOnMouseDown)
                _nativeControl.MouseDown += _nativeControl_MouseDown;
            if (_fireOnMouseDown && !shouldFireOnMouseDown)
                _nativeControl.MouseDown -= _nativeControl_MouseDown;

            _fireOnMouseDown = shouldFireOnMouseDown;


            if (!_fireOnMouseUp && shouldFireOnMouseUp)
                _nativeControl.MouseUp += _nativeControl_MouseUp;
            if (_fireOnMouseUp && !shouldFireOnMouseUp)
                _nativeControl.MouseUp -= _nativeControl_MouseUp;

            _fireOnMouseUp = shouldFireOnMouseUp;
        }

        protected virtual void OnAnimate()
        { 
        
        }

        private void _nativeControl_MouseEnter(object sender, Framework.Input.MouseEventArgs e)
        {
            _widget.OnMouseEnterAction?.Invoke(_widget);

            OnUpdate();
        }

        private void _nativeControl_MouseLeave(object sender, Framework.Input.MouseEventArgs e)
        {
            _widget.OnMouseLeaveAction?.Invoke(_widget);

            OnUpdate();
        }

        private void _nativeControl_MouseDown(object sender, Framework.Input.MouseEventArgs e)
        {
            _widget.OnMouseDownAction?.Invoke(_widget);

            OnUpdate();
        }

        private void _nativeControl_MouseUp(object sender, Framework.Input.MouseEventArgs e)
        {
            _widget.OnMouseUpAction?.Invoke(_widget);

            OnUpdate();
        }
    }
}
