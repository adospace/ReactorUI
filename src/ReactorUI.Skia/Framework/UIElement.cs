using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public class UIElement
    {
        #region Public Properties
        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    Invalidate(InvalidateMode.Measure);
                    OnVisibileChanged();
                }
            }
        }

        protected virtual void OnVisibileChanged()
        {

        }

        private bool _isHitTestVisible;
        public bool IsHitTestVisible
        {
            get { return _isHitTestVisible; }
            set
            {
                if (_isHitTestVisible != value)
                {
                    _isHitTestVisible = value;
                    OnIsHitTestVisibleChanged();
                }
            }
        }

        protected virtual void OnIsHitTestVisibleChanged()
        {

        }
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    Invalidate(InvalidateMode.Render);
                }
            }
        }
        private double _opacity;
        public double Opacity
        {
            get { return _opacity; }
            set
            {
                if (_opacity != value)
                {
                    _opacity = value;
                    Invalidate(InvalidateMode.Render);
                    System.Diagnostics.Debug.WriteLine("Framework.Element.Opacity -> {0}", value);
                }
            }
        }
        private Transform _transform;
        public Transform Transform
        {
            get { return _transform; }
            set
            {
                if (_transform != value)
                {
                    _transform = value;
                    Invalidate(InvalidateMode.Render);
                }
            }
        }
        #endregion

        #region Public Events
        public event EventHandler<Input.MouseEventArgs> MouseEnter;
        protected virtual void OnMouseEnter(double x, double y, Input.MouseEventsContext context)
        {
            IsMouseOver = true;
            MouseEnter?.Invoke(this, new Input.MouseEventArgs(context.MouseButtons, context.Clicks, x, y, context.Delta));
            System.Diagnostics.Debug.WriteLine($"{this} OnMouseEnter");
        }
        public event EventHandler<Input.MouseEventArgs> MouseMove;
        protected virtual void OnMouseMove(double x, double y, Input.MouseEventsContext context)
        {
            MouseMove?.Invoke(this, new Input.MouseEventArgs(context.MouseButtons, context.Clicks, x, y, context.Delta));
            //System.Diagnostics.Debug.WriteLine($"{this} OnMouseMove");
        }
        public event EventHandler<Input.MouseEventArgs> MouseLeave;
        protected virtual void OnMouseLeave(double x, double y, Input.MouseEventsContext context)
        {
            IsMouseOver = false;
            MouseLeave?.Invoke(this, new Input.MouseEventArgs(context.MouseButtons, context.Clicks, x, y, context.Delta));
            System.Diagnostics.Debug.WriteLine($"{this} OnMouseLeave");
        }

        public event EventHandler<Input.MouseEventArgs> MouseDown;
        protected virtual void OnMouseDown(double x, double y, Input.MouseEventsContext context)
        {
            MouseDown?.Invoke(this, new Input.MouseEventArgs(context.MouseButtons, context.Clicks, x, y, context.Delta));
            System.Diagnostics.Debug.WriteLine($"{this} OnMouseDown");
        }

        public event EventHandler<Input.MouseEventArgs> MouseUp;
        protected virtual void OnMouseUp(double x, double y, Input.MouseEventsContext context)
        {
            MouseUp?.Invoke(this, new Input.MouseEventArgs(context.MouseButtons, context.Clicks, x, y, context.Delta));
            System.Diagnostics.Debug.WriteLine($"{this} OnMouseUp");
        }
        #endregion

        #region Layout Engine
        private bool _layoutSuspended = false;
        internal void SuspendLayout()
        {
            _layoutSuspended = true;
        }

        internal void ResumeLayout()
        {
            if (_layoutSuspended)
            {
                _layoutSuspended = false;
                Invalidate(InvalidateMode.Measure);
            }
        }
        #endregion

        public Size DesiredSize { get; private set; }

        ///Measure Pass
        private Size _previousAvailableSize;
        private bool _measureIsDirty = true;
        public void Measure(Size availableSize)
        {
            if (_layoutSuspended)
                return;

            if (!this.IsVisible)
            {
                this.DesiredSize = new Size();
                this._measureIsDirty = false;
                return;
            }

            var isCloseToPreviousMeasure = _previousAvailableSize.IsEmpty ? false : availableSize.IsCloseTo(this._previousAvailableSize);

            if (!this._measureIsDirty && isCloseToPreviousMeasure)
                return;

            this._previousAvailableSize = availableSize;
            var desiredSize = this.MeasureCore(availableSize);
            if (double.IsNaN(desiredSize.Width) ||
                double.IsInfinity(desiredSize.Width) ||
                double.IsNaN(desiredSize.Height) ||
                double.IsInfinity(desiredSize.Height))
                throw new ArgumentException("measure pass must return valid size");

            this.DesiredSize = desiredSize;
            this._measureIsDirty = false;
        }
        protected virtual Size MeasureCore(Size availableSize)
        {
            return new Size();
        }

        ///Arrange Pass
        private Rect _finalRect = Rect.Empty;
        private Rect _previousFinalRect = Rect.Empty;

        private bool _arrangeIsDirty = true;
        private bool _renderIsDirty = false;

        public void Arrange(Rect finalRect)
        {
            if (_layoutSuspended)
                return;

            if (this._measureIsDirty)
                this.Measure(finalRect.Size);

            if (!this.IsVisible)
                return;

            var isCloseToPreviousArrange = this._previousFinalRect.IsEmpty ? false :
                finalRect.IsCloseTo(this._previousFinalRect);

            if (!this._arrangeIsDirty && isCloseToPreviousArrange)
                return;

            this._renderIsDirty = true;
            this._previousFinalRect = finalRect;
            this.ArrangeCore(finalRect);

            this._finalRect = finalRect;

            this._arrangeIsDirty = false;
        }
        protected virtual void ArrangeCore(Rect finalRect)
        {
        }

        ///Render Pass
        public void Render(SKCanvas skCanvas)
        {
            if (_layoutSuspended)
                return;

            this.RenderCore(new RenderContext(skCanvas));

            this._renderIsDirty = false;
        }

        protected virtual void RenderCore(RenderContext context)
        {

        }

        public UIElement Parent { get; internal set; }

        protected void Invalidate(InvalidateMode mode)
        {
            if (_layoutSuspended)
                return;

            if (mode == InvalidateMode.Measure)
            {
                _arrangeIsDirty = true;
                _renderIsDirty = true;
                if (!_measureIsDirty)
                {
                    _measureIsDirty = true;
                    Parent?.Invalidate(mode);
                    Invalidated?.Invoke(this, new InvalidatedEventArgs(mode));
                }
            }
            else if (mode == InvalidateMode.Arrange)
            {
                _renderIsDirty = true;
                if (!_arrangeIsDirty)
                {
                    _arrangeIsDirty = true;
                    Parent?.Invalidate(mode);
                    Invalidated?.Invoke(this, new InvalidatedEventArgs(mode));
                }
            }
            else if (mode == InvalidateMode.Render)
            {
                if (!_renderIsDirty)
                {
                    _renderIsDirty = true;
                    Parent?.Invalidate(mode);
                    Invalidated?.Invoke(this, new InvalidatedEventArgs(mode));
                }
            }
        }

        public event EventHandler<InvalidatedEventArgs> Invalidated;

        /// Mouse events
        public void HandleMouseMove(double x, double y, Input.MouseEventsContext mouseEventsContext)
        {
            if (IsHitTestVisible && IsVisible)
                HitTestCore(x, y, mouseEventsContext);
        }

        protected virtual void HitTestCore(double x, double y, Input.MouseEventsContext mouseEventsContext)
        {

        }

        public bool IsMouseOver { get; private set; }
        protected virtual void OnHitTest(double x, double y, Input.MouseEventsContext context)
        {

        }

        public void HandleMouseDown(double x, double y, Input.MouseEventsContext mouseEventsContext)
        {
            if (IsMouseOver || mouseEventsContext.CaptureTo == this)
                MouseDownCore(x, y, mouseEventsContext);
        }

        protected virtual void MouseDownCore(double x, double y, Input.MouseEventsContext mouseEventsContext)
        {

        }

        public void HandleMouseUp(double x, double y, Input.MouseEventsContext mouseEventsContext)
        {
            if (IsMouseOver || mouseEventsContext.CaptureTo == this)
                MouseUpCore(x, y, mouseEventsContext);
        }

        protected virtual void MouseUpCore(double x, double y, Input.MouseEventsContext mouseEventsContext)
        {

        }
    }
}
