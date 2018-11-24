using System;
using System.Collections.Generic;
using System.Text;
using ReactorUI.Primitives;
using ReactorUI.Skia.Framework.Input;
using SkiaSharp;

namespace ReactorUI.Skia.Framework
{
    public class ContentControl : Control
    {
        #region Public Properties
        private object _content;
        public object Content
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    if (_content != null && Content is UIElement)
                        ((UIElement)_content).Parent = null;
                    _content = value;
                    if (_content != null && Content is UIElement)
                        ((UIElement)_content).Parent = this;

                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        #endregion

        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            // Compute the chrome size added by padding
            var paddingSize = new Size(this.Padding.Left + this.Padding.Right, this.Padding.Top + this.Padding.Bottom);
            if (_content == null)
                return paddingSize;

            //If we have a child
            if (_content is UIElement child)
            {
                // Remove size of padding only from child's reference size.
                var childConstraint = new Size(Math.Max(0.0, availableSize.Width - paddingSize.Width),
                    Math.Max(0.0, availableSize.Height - paddingSize.Height));


                child.Measure(childConstraint);
                var childSize = child.DesiredSize;
                if (!childSize.IsEmpty)
                {
                    // Now use the returned size to drive our size, by adding back the margins, etc.
                    return new Size(
                        childSize.Width + paddingSize.Width,
                        childSize.Height + paddingSize.Height);
                }

                return paddingSize;
            }
            else
            {
                var text = this.Content.ToString();

                var paint = new SKPaint();

                paint.ApplyFont(FontFamily, FontSize, FontStyle, FontStretch, FontWeight);

                var bounds = new SKRect();
                paint.MeasureText(text, ref bounds);

                return new Size(bounds.Width + paddingSize.Width, bounds.Height + paddingSize.Height);
            }
        }
        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            var borderThickness = this.BorderThickness;

            var boundRect = new Rect(0, 0, finalSize.Width, finalSize.Height);
            var innerRect = new Rect(
                boundRect.X + borderThickness.Left,
                boundRect.Y + borderThickness.Top,
                Math.Max(0.0, boundRect.Width - borderThickness.Left - borderThickness.Right),
                Math.Max(0.0, boundRect.Height - borderThickness.Top - borderThickness.Bottom));

            //  arrange child
            if (Content is UIElement child)
            {
                var padding = this.Padding;
                var childRect = new Rect(
                    innerRect.X + padding.Left,
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
            base.RenderOverride(context);

            if (Content == null)
                return;

            if (Content is UIElement child)
            {
                child.Render(context.Canvas);
            }
            else
            {
                var text = Content.ToString();
                var finalWidth = this.RenderSize.Width - (Padding.Left + Padding.Right);
                var finalHeight = this.RenderSize.Height - (Padding.Top + Padding.Bottom);

                float x = (float)Padding.Left;
                float y = (float)Padding.Top + (float)DesiredSize.Height;

                var paint = new SKPaint();

                paint.ApplyBrush(Foreground);
                paint.ApplyFont(FontFamily, FontSize, FontStyle, FontStretch, FontWeight);

                context.Canvas.DrawText(text, x, y, paint);
            }

        }
        #endregion

        #region Mouse
        protected override void OnHitTest(int x, int y, MouseEventsContext context)
        {
            if (Background != null)
                base.OnHitTest(x, y, context);

            if (Content is UIElement child)
                child.HandleMouseMove(x, y, context);

            base.OnHitTest(x, y, context);
        }

        protected override void OnMouseDown(int x, int y, MouseEventsContext context)
        {
            if (Content is UIElement child)
                child.HandleMouseDown(x, y, context);
            base.OnMouseDown(x, y, context);
        }

        protected override void OnMouseUp(int x, int y, MouseEventsContext context)
        {
            if (Content is UIElement child)
                child.HandleMouseUp(x, y, context);
            base.OnMouseUp(x, y, context);
        }

        #endregion
    }
}
