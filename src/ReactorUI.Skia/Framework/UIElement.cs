using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    internal class UIElement
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
        private bool _layoutInvalid = false;

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

            this._layoutInvalid = true;
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
            if (this._layoutInvalid)
            {
                this.RenderCore(new RenderContext(skCanvas, _finalRect.Location));


                this._layoutInvalid = false;
            }
        }

        protected virtual void RenderCore(RenderContext context)
        {

        }


    }
}
