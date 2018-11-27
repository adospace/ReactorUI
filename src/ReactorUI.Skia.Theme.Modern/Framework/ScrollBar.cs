using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    internal class ScrollBar : Control
    {
        #region Public Properties
        private Orientation _orientation;
        public Orientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        public double _offset;
        public double Offset
        {
            get => _offset;
            set
            {
                if (_offset != value)
                {
                    _offset = value;
                    Invalidate(InvalidateMode.Render);
                    OnOffsetChanged();
                }
            }
        }
        public double _viewport;
        public double Viewport
        {
            get => _viewport;
            set
            {
                if (_viewport != value)
                {
                    _viewport = value;
                    Invalidate(InvalidateMode.Render);
                }
            }
        }
        public double _extent;
        public double Extent
        {
            get => _extent;
            set
            {
                if (_extent != value)
                {
                    _extent = value;
                    Invalidate(InvalidateMode.Render);
                }
            }
        }
        public Brush _thumbBrush;
        public Brush ThumbBrush
        {
            get => _thumbBrush;
            set
            {
                if (_thumbBrush != value)
                {
                    _thumbBrush = value;
                    Invalidate(InvalidateMode.Render);
                }
            }
        }
        #endregion

        #region Public Events
        public event EventHandler OffsetChanged;
        protected virtual void OnOffsetChanged()
        {
            OffsetChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            var mySize = default(Size);
            var border = BorderThickness.ToSize();
            var padding = Padding.ToSize();

            // Combine into total decorating size
            mySize = new Size(border.Width + padding.Width, border.Height + padding.Height);

            return mySize;

        }
        #endregion

        #region Arrange Pass

        #endregion

        #region Render Pass
        protected override void RenderOverride(RenderContext context)
        {
            base.RenderOverride(context);

            if (Orientation == Orientation.Vertical)
            {
                var thumbHeight = RenderSize.Height * Viewport / Extent;
                var thumbY = (RenderSize.Height - thumbHeight) * Offset / Extent;

                var paint = new SKPaint();
                paint.ApplyBrush(ThumbBrush, Opacity);

                context.Canvas.DrawRect(
                    new SKRect(0.0f, (float)thumbY, (float)RenderSize.Width, (float)(thumbY + thumbHeight)),
                    paint
                    );
            }
            else
            {
                var thumbWidth = RenderSize.Width * Viewport / Extent;
                var thumbX = (RenderSize.Width - thumbWidth) * Offset / Extent;

                var paint = new SKPaint();
                paint.ApplyBrush(ThumbBrush, Opacity);

                context.Canvas.DrawRect(
                    new SKRect((float)thumbX, 0.0f, (float)(thumbX + thumbWidth), (float)(RenderSize.Height)),
                    paint
                    );
            }
        }
        #endregion

        #region Mouse
        bool _mouseDown;
        Point _pointMouseDown;
        protected override void OnMouseDown(int x, int y, Framework.Input.MouseEventsContext context)
        {
            _pointMouseDown = new Point(x, y);
            if (Orientation == Orientation.Vertical)
            {
                var thumbHeight = RenderSize.Height * Viewport / Extent;
                var thumbY = (RenderSize.Height - thumbHeight) * Offset / Extent;

                if (new Rect(0.0, thumbY, RenderSize.Width, thumbHeight).Contains(_pointMouseDown))
                {
                    _mouseDown = true;
                    context.CaptureTo = this;
                }
            }
            else
            {
                var thumbWidth = RenderSize.Width * Viewport / Extent;
                var thumbX = (RenderSize.Width - thumbWidth) * Offset / Extent;

                if (new Rect(thumbX, 0.0, thumbWidth, RenderSize.Height).Contains(_pointMouseDown))
                {
                    _mouseDown = true;
                    context.CaptureTo = this;
                }
            }

            base.OnMouseDown(x, y, context);
        }

        protected override void OnMouseMove(int x, int y, Framework.Input.MouseEventsContext context)
        {
            if (_mouseDown)
            {
                var pointMouseMove = new Point(x, y);
                if (Orientation == Orientation.Vertical)
                {
                    var thumbHeight = RenderSize.Height * Viewport / Extent;
                    var thumbY = (RenderSize.Height - thumbHeight) * Offset / Extent;
                    var delta = pointMouseMove.Y - _pointMouseDown.Y;

                    var newThumbY = thumbY + delta;
                    newThumbY = Math.Max(0.0, newThumbY);
                    newThumbY = Math.Min(newThumbY, RenderSize.Height - thumbHeight);

                    Offset = newThumbY * Extent / (RenderSize.Height - thumbHeight);

                    delta = newThumbY - thumbY;

                    pointMouseMove = new Point(pointMouseMove.X, _pointMouseDown.Y + delta);
                }
                else
                {
                    var thumbWidth = RenderSize.Width * Viewport / Extent;
                    var thumbX = (RenderSize.Width - thumbWidth) * Offset / Extent;
                    var delta = pointMouseMove.X - _pointMouseDown.X;

                    var newThumbX = thumbX + delta;
                    newThumbX = Math.Max(0.0, newThumbX);
                    newThumbX = Math.Min(newThumbX, RenderSize.Width - thumbWidth);

                    Offset = newThumbX * Extent / (RenderSize.Width - thumbWidth);

                    delta = newThumbX - thumbX;

                    pointMouseMove = new Point(_pointMouseDown.X + delta, pointMouseMove.Y);
                }

                _pointMouseDown = pointMouseMove;
            }

            base.OnMouseMove(x, y, context);
        }

        protected override void OnMouseUp(int x, int y, Framework.Input.MouseEventsContext context)
        {
            _mouseDown = false;
            base.OnMouseUp(x, y, context);
        }
        #endregion
    }

}
