using ReactorUI.Skia.Framework;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Theme.Modern.Framework
{
    internal class Button : ReactorUI.Skia.Framework.Button
    {
        public Button()
        { 
        }

        #region Render Pass
        protected override void RenderOverride(RenderContext context)
        {
            {
                var paint = new SKPaint
                {
                    Style = SKPaintStyle.StrokeAndFill
                };

                paint.ApplyBrush(Background ?? Brushes.NeutralWhite, Opacity);

                context.Canvas.DrawRoundRect(new SKRect(0, 0, (float)RenderSize.Width, (float)RenderSize.Height), 2.0f, 2.0f, paint);
            }

            base.RenderOverride(context);

            {
                var paint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = (float)BorderThickness.UniformLength
                };

                paint.ApplyBrush(BorderBrush ?? Brushes.NeutralGray110, Opacity);

                context.Canvas.DrawRoundRect(new SKRect((float)BorderThickness.UniformLength, (float)BorderThickness.UniformLength, (float)(RenderSize.Width - BorderThickness.UniformLength), (float)(RenderSize.Height - BorderThickness.UniformLength)), 2.0f, 2.0f, paint);
            }
        }
        #endregion
    }
}
