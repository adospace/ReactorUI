using ReactorUI.Animation;
using ReactorUI.Primitives;
using ReactorUI.Skia.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public partial class ScrollViewer : FrameworkElement
    {
        #region Public Properties
        private UIElement _child;
        public UIElement Child
        {
            get { return _child; }
            set
            {
                if (_child != value)
                {
                    if (_child != null)
                        _child.Parent = null;

                    if (value != null && !(value is IScrollableUIElement))
                        throw new InvalidOperationException($"Type {value.GetType()} can't be child of ScrollViewer: it must implement {typeof(IScrollableUIElement)} interface");

                    _child = value;

                    if (_child != null)
                        _child.Parent = this;
                }
            }
        }

        private OffsetAnimationActuator _animation;
        internal void Animate()
        {
            if (_offsetMove != default)
            {
                var child = (IScrollableUIElement)Child;
                if (_mouseDown)
                {
                    child.Offset += _offsetMove;
                    _ptMouseDown = _ptMouseMove;
                    _animation = null;
                }
                else
                {
                    _animation = new OffsetAnimationActuator((IScrollableUIElement)Child, new VectorAnimation(_offsetMove, default, 3000, Easing.Exponential.Out, keepTargetValue: false));
                }

                _offsetMove = default;
            }


            if (!(_animation?.Tick()).GetValueOrDefault())
                _animation = null;
        }

        private ScrollMode _verticalScrollMode;
        public ScrollMode VerticalScrollMode
        {
            get => _verticalScrollMode;
            set
            {
                if (_verticalScrollMode != value)
                {
                    _verticalScrollMode = value;
                }
            }
        }

        private ScrollMode _horizontalScrollMode;
        public ScrollMode HorizontalScrollMode
        {
            get => _horizontalScrollMode;
            set
            {
                if (_horizontalScrollMode != value)
                {
                    _horizontalScrollMode = value;
                }
            }
        }
        #endregion

        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            //If we have a child
            if (_child != null)
            {
                _child.Measure(availableSize);
                return this._child.DesiredSize;
            }

            return default;
        }
        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            //  arrange child
            var child = this._child;
            if (child != null)
            {
                child.Arrange(new Rect(new Point(), finalSize));
            }

            return finalSize;
        }
        #endregion

        #region Render Pass
        protected override void RenderOverride(RenderContext context)
        {
            var child = this._child;
            if (child != null)
            {
                child.Render(context.Canvas);
            }
        }
        #endregion

        #region Mouse/Pan
        bool _mouseDown = false;
        Vector _offsetMove;
        Point _ptMouseDown;
        Point _ptMouseMove;
        protected override void OnMouseDown(double x, double y, MouseEventsContext context)
        {
            _mouseDown = true;
            _ptMouseDown = new Point(x, y);
            context.CaptureTo = this;
            _animation = null;

            base.OnMouseDown(x, y, context);
        }

        protected override void OnMouseMove(double x, double y, MouseEventsContext context)
        {
            if (_mouseDown)
            {
                if (Child is IScrollableUIElement child)
                {
                    _ptMouseMove = new Point(x, y);
                    System.Diagnostics.Debug.WriteLine($"OnMouseMove({_ptMouseMove} {context.MouseButtons})");
                    _offsetMove = _ptMouseDown - _ptMouseMove;
                    //_ptMouseDown = currentMouseDown;
                }
            }

            base.OnMouseMove(x, y, context);
        }

        protected override void OnMouseUp(double x, double y, MouseEventsContext context)
        {
            if (_mouseDown)
            {
                _mouseDown = false;

                if (Child is IScrollableUIElement child)
                {
                    _ptMouseMove = new Point(x, y);
                    System.Diagnostics.Debug.WriteLine($"OnMouseUp({_ptMouseMove} {context.MouseButtons})");
                    _offsetMove = _ptMouseDown - _ptMouseMove;
                    //_ptMouseDown = currentMouseDown;
                }

            }

            base.OnMouseUp(x, y, context);
        }
        #endregion
    }
}
