using System;
using System.Collections.Generic;
using System.Text;
using ReactorUI.Primitives;

namespace ReactorUI.Skia.Framework
{
    internal class Border : FrameworkElement
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
                    _child = value;
                }
            }
        }
        private Thickness _borderThickness;
        public Thickness BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                if (!_borderThickness.IsCloseTo(value))
                {
                    _borderThickness = value;
                }
            }
        }
        private Thickness _padding;
        public Thickness Padding
        {
            get { return _padding; }
            set
            {
                if (!_padding.IsCloseTo(value))
                {
                    _padding = value;
                }
            }
        }
        private Brush _borderBrush;
        public Brush BorderBrush
        {
            get { return _borderBrush; }
            set
            {
                if (_borderBrush != value)
                {
                    _borderBrush = value;
                }
            }
        }
        #endregion

        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            var mySize = default(Size);
            var border = BorderThickness.ToSize();
            var padding = Padding.ToSize();

            //If we have a child
            if (_child != null)
            {
                // Combine into total decorating size
                var combined = new Size(border.Width + padding.Width, border.Height + padding.Height);

                // Remove size of border only from child's reference size.
                var childConstraint = new Size(Math.Max(0.0, availableSize.Width - combined.Width),
                    Math.Max(0.0, availableSize.Height - combined.Height));

                _child.Measure(childConstraint);
                var childSize = this._child.DesiredSize;

                // Now use the returned size to drive our size, by adding back the margins, etc.
                mySize.Width = childSize.Width + combined.Width;
                mySize.Height = childSize.Height + combined.Height;
            }
            else
            {
                // Combine into total decorating size
                mySize = new Size(border.Width + padding.Width, border.Height + padding.Height);
            }

            return mySize;
        }
        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            var borderThickness = this.BorderThickness;

            var boundRect = new Rect(0, 0, finalSize.Width, finalSize.Height);
            var innerRect = new Rect(boundRect.X + borderThickness.Left,
                boundRect.Y + borderThickness.Top,
                Math.Max(0.0, boundRect.Width - borderThickness.Left - borderThickness.Right),
                Math.Max(0.0, boundRect.Height - borderThickness.Top - borderThickness.Bottom));

            //  arrange child
            var child = this._child;
            var padding = this.Padding;
            if (child != null)
            {
                var childRect = new Rect(innerRect.X + padding.Left,
                    innerRect.Y + padding.Top,
                    Math.Max(0.0, innerRect.Width - padding.Left - padding.Right),
                    Math.Max(0.0, innerRect.Height - padding.Top - padding.Bottom));

                child.Arrange(childRect);
            }

            return finalSize;
        }
        #endregion

        #region Render Pass
        protected override void RenderOverride(RenderContext context)
        {
            var finalWidth = this.RenderSize.Width - (BorderThickness.Left + BorderThickness.Right);
            var finalHeight = this.RenderSize.Height - (BorderThickness.Top + BorderThickness.Bottom);
            context.Canvas.DrawRect((float)context.Offset.X, (float)context.Offset.Y, (float)this.RenderSize.Width, (float)this.RenderSize.Height,
                new SkiaSharp.SKPaint()
                {
                    IsStroke = true,
                    Color = new SkiaSharp.SKColor(),
                    StrokeWidth = (float)BorderThickness.UniformLength
                });

            if (Child != null)
                Child.Render(context.Canvas);
        }
        #endregion
    }
}
