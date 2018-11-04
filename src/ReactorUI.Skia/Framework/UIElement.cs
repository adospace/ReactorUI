using ReactorUI.Primitives;
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

        private Size _desiredSize = Size.Empty;
        private Size _renderSize = Size.Empty;

        ///Measure Pass
        private Size _previousAvailableSize = Size.Empty;
        private bool _measureIsDirty = true;
        public virtual void Measure(Size availableSize)
        {

            if (!this.IsVisible)
            {
                this._desiredSize = Size.Empty;
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

            this._desiredSize = desiredSize;
            this._measureIsDirty = false;
        }
        protected virtual Size MeasureCore(Size availableSize)
        {
            return Size.Empty;
        }

    }
}
