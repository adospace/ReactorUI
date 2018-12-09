using ReactorUI.Primitives;
using ReactorUI.Skia.Framework.Input;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public class FrameworkElement : UIElement
    {
        #region Private Classes
        private struct MinMax
        {
            internal double minWidth;

            internal double maxWidth;

            internal double minHeight;

            internal double maxHeight;

            internal MinMax(FrameworkElement e)
            {
                maxHeight = e.MaxHeight;
                minHeight = e.MinHeight;
                double height = e.Height;
                double val = double.IsNaN(height) ? double.PositiveInfinity : height;
                maxHeight = Math.Max(Math.Min(val, maxHeight), minHeight);
                val = (double.IsNaN(height) ? 0.0 : height);
                minHeight = Math.Max(Math.Min(maxHeight, val), minHeight);
                maxWidth = e.MaxWidth;
                minWidth = e.MinWidth;
                height = e.Width;
                double val2 = double.IsNaN(height) ? double.PositiveInfinity : height;
                maxWidth = Math.Max(Math.Min(val2, maxWidth), minWidth);
                val2 = (double.IsNaN(height) ? 0.0 : height);
                minWidth = Math.Max(Math.Min(maxWidth, val2), minWidth);
            }
        }
        #endregion

        #region Public Properties
        private Thickness _margin;
        public Thickness Margin
        {
            get { return _margin; }
            set
            {
                if (!_margin.IsCloseTo(value))
                {
                    _margin = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }

        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                if (!DoubleUtil.AreClose(_width, value))
                {
                    _width = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                if (!DoubleUtil.AreClose(_height, value))
                {
                    _height = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }

        private double _minWidth;
        public double MinWidth
        {
            get { return _minWidth; }
            set
            {
                if (!DoubleUtil.AreClose(_minWidth, value))
                {
                    _minWidth = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        private double _minHeight;
        public double MinHeight
        {
            get { return _minHeight; }
            set
            {
                if (!DoubleUtil.AreClose(_minHeight, value))
                {
                    _minHeight = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }

        private double _maxWidth;
        public double MaxWidth
        {
            get { return _maxWidth; }
            set
            {
                if (!DoubleUtil.AreClose(_maxWidth, value))
                {
                    _maxWidth = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        private double _maxHeight;
        public double MaxHeight
        {
            get { return _maxHeight; }
            set
            {
                if (!DoubleUtil.AreClose(_maxHeight, value))
                {
                    _maxHeight = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }

        private HorizontalAlignment _horizontalAlignment;
        public HorizontalAlignment HorizontalAlignment
        {
            get { return _horizontalAlignment; }
            set
            {
                if (_horizontalAlignment != value)
                {
                    _horizontalAlignment = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }

        private VerticalAlignment _verticalAlignment;
        public VerticalAlignment VerticalAlignment
        {
            get { return _verticalAlignment; }
            set
            {
                if (_verticalAlignment != value)
                {
                    _verticalAlignment = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        #endregion

        #region Measure Pass
        private Size _unclippedDesiredSize;
        protected Vector _visualOffset;

        protected sealed override Size MeasureCore(Size availableSize)
        {
            var margin = this.Margin;
            var marginWidth = margin.Left + margin.Right;
            var marginHeight = margin.Top + margin.Bottom;

            var frameworkAvailableSize = new Size(
                Math.Max(availableSize.Width - marginWidth, 0),
                Math.Max(availableSize.Height - marginHeight, 0));

            var mm = new MinMax(this);

            frameworkAvailableSize = new Size(
                Math.Max(mm.minWidth, Math.Min(frameworkAvailableSize.Width, mm.maxWidth)),
                Math.Max(mm.minHeight, Math.Min(frameworkAvailableSize.Height, mm.maxHeight)));

            var desideredSize = this.MeasureOverride(frameworkAvailableSize);

            desideredSize = new Size(
                Math.Max(desideredSize.Width, mm.minWidth),
                Math.Max(desideredSize.Height, mm.minHeight));

            this._unclippedDesiredSize = desideredSize;

            //var clipped = false;

            if (desideredSize.Width > mm.maxWidth)
            {
                desideredSize = new Size(mm.maxWidth, desideredSize.Height);
                //clipped = true;
            }

            if (desideredSize.Height > mm.maxHeight)
            {
                desideredSize = new Size(desideredSize.Width, mm.maxHeight);
                //clipped = true;
            }

            var clippedDesiredWidth = desideredSize.Width + marginWidth;
            var clippedDesiredHeight = desideredSize.Height + marginHeight;

            if (clippedDesiredWidth > availableSize.Width)
            {
                clippedDesiredWidth = availableSize.Width;
                //clipped = true;
            }

            if (clippedDesiredHeight > availableSize.Height)
            {
                clippedDesiredHeight = availableSize.Height;
                //clipped = true;
            }

            return new Size(Math.Max(0, clippedDesiredWidth), Math.Max(0, clippedDesiredHeight));
        }

        protected virtual Size MeasureOverride(Size availableSize)
        {
            return new Size();
        }
        #endregion

        #region Arrange Pass
        public Size RenderSize { get; private set; }

        protected sealed override void ArrangeCore(Rect finalRect)
        {
            var arrangeSize = finalRect.Size;

            var margin = this.Margin;
            var marginWidth = margin.Left + margin.Right;
            var marginHeight = margin.Top + margin.Bottom;

            arrangeSize.Width = Math.Max(0, arrangeSize.Width - marginWidth);
            arrangeSize.Height = Math.Max(0, arrangeSize.Height - marginHeight);

            if (this._unclippedDesiredSize.IsEmpty)
                return;

            if (DoubleUtil.AreClose(arrangeSize.Width, this._unclippedDesiredSize.Width) ||
                arrangeSize.Width < this._unclippedDesiredSize.Width)
            {
                //this.needClipBounds = true;
                arrangeSize.Width = this._unclippedDesiredSize.Width;
            }

            if (DoubleUtil.AreClose(arrangeSize.Height, this._unclippedDesiredSize.Height) ||
                arrangeSize.Height < this._unclippedDesiredSize.Height)
            {
                //this.needClipBounds = true;
                arrangeSize.Height = this._unclippedDesiredSize.Height;
            }

            if (this.HorizontalAlignment != HorizontalAlignment.Stretch)
            {
                arrangeSize.Width = this._unclippedDesiredSize.Width;
            }

            if (this.VerticalAlignment != VerticalAlignment.Stretch)
            {
                arrangeSize.Height = this._unclippedDesiredSize.Height;
            }

            var mm = new MinMax(this);

            var effectiveMaxWidth = Math.Max(this._unclippedDesiredSize.Width, mm.maxWidth);
            if (DoubleUtil.AreClose(effectiveMaxWidth, arrangeSize.Width) ||
                effectiveMaxWidth < arrangeSize.Width)
            {
                //this.needClipBounds = true;
                arrangeSize.Width = effectiveMaxWidth;
            }

            var effectiveMaxHeight = Math.Max(this._unclippedDesiredSize.Height, mm.maxHeight);
            if (DoubleUtil.AreClose(effectiveMaxHeight, arrangeSize.Height) ||
                effectiveMaxHeight < arrangeSize.Height)
            {
                //this.needClipBounds = true;
                arrangeSize.Height = effectiveMaxHeight;
            }

            var oldRenderSize = this.RenderSize;
            var innerInkSize = this.ArrangeOverride(arrangeSize);

            if (innerInkSize.IsEmpty)
                throw new InvalidOperationException("arrangeOverride() can't return null");

            this.RenderSize = innerInkSize;

            var clippedInkSize = new Size(Math.Min(innerInkSize.Width, mm.maxWidth),
                Math.Min(innerInkSize.Height, mm.maxHeight));

            var clientSize = new Size(Math.Max(0, finalRect.Width - marginWidth),
                Math.Max(0, finalRect.Height - marginHeight));

            var offset = this.ComputeAlignmentOffset(clientSize, clippedInkSize);

            offset.X += finalRect.X + margin.Left;
            offset.Y += finalRect.Y + margin.Top;

            var oldOffset = this._visualOffset;
            if (oldOffset.Equals(default(Vector)) ||
                (!DoubleUtil.AreClose(oldOffset.X, offset.X) || !DoubleUtil.AreClose(oldOffset.Y, offset.Y))
                )
                this._visualOffset = offset;
        }

        private Vector ComputeAlignmentOffset(Size clientSize, Size inkSize)
        {
            var offset = new Vector();

            var ha = this.HorizontalAlignment;
            var va = this.VerticalAlignment;


            if (ha == HorizontalAlignment.Stretch
                && inkSize.Width > clientSize.Width)
            {
                ha = HorizontalAlignment.Left;
            }

            if (va == VerticalAlignment.Stretch
                && inkSize.Height > clientSize.Height)
            {
                va = VerticalAlignment.Top;
            }

            if (ha == HorizontalAlignment.Center
                || ha == HorizontalAlignment.Stretch)
            {
                offset.X = (clientSize.Width - inkSize.Width) * 0.5;
            }
            else if (ha == HorizontalAlignment.Right)
            {
                offset.X = clientSize.Width - inkSize.Width;
            }
            else
            {
                offset.X = 0;
            }

            if (va == VerticalAlignment.Center
                || va == VerticalAlignment.Stretch)
            {
                offset.Y = (clientSize.Height - inkSize.Height) * 0.5;
            }
            else if (va == VerticalAlignment.Bottom)
            {
                offset.Y = clientSize.Height - inkSize.Height;
            }
            else
            {
                offset.Y = 0;
            }

            return offset;
        }

        protected virtual Size ArrangeOverride(Size finalSize)
        {
            return finalSize;
        }
        #endregion

        #region Render Pass
        protected sealed override void RenderCore(RenderContext context)
        {
            using (new SKAutoCanvasRestore(context.Canvas))
            {
                context.Canvas.Translate((float)_visualOffset.X, (float)_visualOffset.Y);

                context.Canvas.ApplyTransform(Transform, RenderSize);
                context.Canvas.ClipRect(new SkiaSharp.SKRect(0.0f, 0.0f, (float)RenderSize.Width, (float)RenderSize.Height));

                RenderOverride(context);

                if (RenderOptions.ShowClipRects)
                {
                    var pt = new SkiaSharp.SKPaint()
                        .IsStroke()
                        .ApplyBrush(new SolidColorBrush(new Color(255, 0, 0)), 1.0f);

                    context.Canvas.DrawRect(new SkiaSharp.SKRect(0.5f, 0.5f, (float)RenderSize.Width -0.5f, (float)RenderSize.Height - 0.5f), pt);
                }
            }

            base.RenderCore(context);
        }

        protected virtual void RenderOverride(RenderContext context)
        {

        }
        #endregion

        #region Hit Test
        bool _mouseEntered = false;
        protected override void HitTestCore(int x, int y, Input.MouseEventsContext context)
        {
            OnHitTest(
                x - (int)_visualOffset.X,
                y - (int)_visualOffset.Y, 
                context);


            base.HitTestCore(x, y, context);
        }

        protected override void OnHitTest(int x, int y, Input.MouseEventsContext context)
        {
            if (RenderSize.Contains(x, y) || context.CaptureTo == this)
            {
                if (!_mouseEntered)
                {
                    OnMouseEnter(x, y, context);
                    _mouseEntered = true;
                }

                OnMouseMove(x, y, context);
            }
            else if (_mouseEntered)
            {
                OnMouseLeave(x, y, context);
                _mouseEntered = false;
            }

            base.OnHitTest(x, y, context);
        }
        protected override void OnVisibileChanged()
        {
            _mouseEntered = false;

            base.OnVisibileChanged();
        }
        protected override void OnIsHitTestVisibleChanged()
        {
            _mouseEntered = false;

            base.OnIsHitTestVisibleChanged();
        }

        protected override void MouseDownCore(int x, int y, Input.MouseEventsContext mouseEventsContext)
        {
            OnMouseDown(
                x - (int)_visualOffset.X, 
                y - (int)_visualOffset.Y, 
                mouseEventsContext);

            base.MouseDownCore(x, y, mouseEventsContext);
        }


        protected override void MouseUpCore(int x, int y, Input.MouseEventsContext mouseEventsContext)
        {
            OnMouseUp(
                x - (int)_visualOffset.X, 
                y - (int)_visualOffset.Y, 
                mouseEventsContext);

            base.MouseUpCore(x, y, mouseEventsContext);
        }
        #endregion
    }
}