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
                }
            }
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
                }
            }
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
                }
            }
        }
        #endregion

        #region Public Events
        public event EventHandler<Input.MouseEventArgs> MouseEnter;
        public event EventHandler<Input.MouseEventArgs> MouseLeave;
        #endregion

        public Size DesiredSize { get; private set; } = Size.Empty;

        ///Measure Pass
        private Size _previousAvailableSize = Size.Empty;
        private bool _measureIsDirty = true;
        public void Measure(Size availableSize)
        {

            if (!this.IsVisible)
            {
                this.DesiredSize = Size.Empty;
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
            return Size.Empty;
        }

        ///Arrange Pass
        private Rect _finalRect = Rect.Empty;
        private Rect _previousFinalRect = Rect.Empty;

        private bool _arrangeIsDirty = true;
        private bool _renderIsDirty = false;

        public void Arrange(Rect finalRect)
        {
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
            this.RenderCore(new RenderContext(skCanvas));

            this._renderIsDirty = false;
        }

        protected virtual void RenderCore(RenderContext context)
        {

        }

        public UIElement Parent { get; internal set; }

        protected void Invalidate(InvalidateMode mode)
        {
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
    }
}
