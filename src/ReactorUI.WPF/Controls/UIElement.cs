using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.WPF.Controls.Primitives;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Styles;

namespace ReactorUI.WPF.Controls
{
    internal class UIElement<T, I, TS> : INativeControl 
        where T : System.Windows.UIElement, new() 
        where I : IUIElement 
        where TS : UIElementStyle<I>
    {
        protected T _nativeControl;

        protected I _widget;

        //protected TS Style => ((IStyledWidget<TS>)_widget)?.Style;

        public void DidMount(IWidget widget)
        {
            _widget = (I)widget;
            _nativeControl ??= new T();

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


            _nativeControl.Opacity = _widget.Opacity;

            bool shouldFireOnMouseEnter = (_widget.OnMouseEnterAction != null);
            bool shouldFireOnMouseLeave = (_widget.OnMouseLeaveAction != null);

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

        private void _nativeControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _widget.OnMouseEnterAction?.Invoke(_widget);

            OnUpdate();
        }

        private void _nativeControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _widget.OnMouseLeaveAction?.Invoke(_widget);

            OnUpdate();
        }
    }
}
