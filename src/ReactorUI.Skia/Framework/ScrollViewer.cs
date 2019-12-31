using ReactorUI.Primitives;
using ReactorUI.Skia.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public class ScrollViewer : FrameworkElement
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

                    if (value != null && !(value is ISupportOffset))
                        throw new InvalidOperationException($"Type {value.GetType()} can't be child of ScrollViewer: it must implement {typeof(ISupportOffset)} interface");

                    _child = value;

                    if (_child != null)
                        _child.Parent = this;
                }
            }
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
        Point _ptMouseDown;
        protected override void OnMouseDown(double x, double y, MouseEventsContext context)
        {
            _mouseDown = true;
            _ptMouseDown = new Point(x, y);
            context.CaptureTo = this;

            base.OnMouseDown(x, y, context);
        }

        protected override void OnMouseMove(double x, double y, MouseEventsContext context)
        {
            if (_mouseDown)
            {
                if (Child is ISupportOffset child)
                {
                    var currentMouseDown = new Point(x, y);
                    child.Offset = child.Offset.Add(_ptMouseDown - currentMouseDown);
                    _ptMouseDown = currentMouseDown;
                }
            }

            base.OnMouseMove(x, y, context);
        }

        protected override void OnMouseUp(double x, double y, MouseEventsContext context)
        {
            if (_mouseDown)
            {
                _mouseDown = false;

                if (Child is ISupportOffset child)
                {
                    var currentMouseDown = new Point(x, y);
                    var remaingingOffset = _ptMouseDown - currentMouseDown;
                    child.Offset = child.Offset.Add(remaingingOffset);

                    
                    
                }
            }

            base.OnMouseUp(x, y, context);
        }
        #endregion
    }
}
