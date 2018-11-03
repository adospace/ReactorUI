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
            if (_fireOnMouseEnterAction != null)
                _nativeControl.MouseEnter -= _nativeControl_MouseEnter;
        }

        public void Update(IWidget widget)
        {
            _widget = (I)widget;
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {
            _nativeControl.IsEnabled = _widget.IsEnabled;
            _nativeControl.IsHitTestVisible = _widget.IsHitTestVisible;
            _nativeControl.Visibility = _widget.IsVisible ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            _nativeControl.Opacity = _widget.Opacity;

            if (_fireOnMouseEnterAction == null && Style?.OnMouseEnterAction != null)
                _nativeControl.MouseEnter += _nativeControl_MouseEnter;
            if (_fireOnMouseEnterAction != null && Style?.OnMouseEnterAction == null)
                _nativeControl.MouseEnter -= _nativeControl_MouseEnter;

            _fireOnMouseEnterAction = Style?.OnMouseEnterAction;

            if (_fireOnMouseLeaveAction == null && Style?.OnMouseLeaveAction != null)
                _nativeControl.MouseLeave += _nativeControl_MouseLeave;
            if (_fireOnMouseLeaveAction != null && Style?.OnMouseLeaveAction == null)
                _nativeControl.MouseLeave -= _nativeControl_MouseLeave;

            _fireOnMouseLeaveAction = Style?.OnMouseLeaveAction;
        }

        private void _nativeControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _fireOnMouseEnterAction(_widget);
            OnUpdate();
        }

        private void _nativeControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _fireOnMouseLeaveAction(_widget);
            OnUpdate();
        }

        private Action<I> _fireOnMouseEnterAction = null;
        private Action<I> _fireOnMouseLeaveAction = null;
    }
}
