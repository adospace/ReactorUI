using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public static class SKCanvasExtensions
    {
        public static void ApplyTransform(this SKCanvas canvas, Transform transform)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas));
            }

            if (transform == null)
            {
                throw new ArgumentNullException(nameof(transform));
            }

            foreach (var operation in transform.Operations)
            {
                if (operation is Transform.Scale)
                    ApplyTransform(canvas, (Transform.Scale)operation);
                else if (operation is Transform.ScaleOrigin)
                    ApplyTransform(canvas, (Transform.ScaleOrigin)operation);
                else if (operation is Transform.ScaleRelativeOrigin)
                    ApplyTransform(canvas, (Transform.ScaleRelativeOrigin)operation);
            }
        }

        private static void ApplyTransform(this SKCanvas canvas, Transform.Scale transformOperation)
        {
            canvas.Scale((float)transformOperation.X, (float)transformOperation.Y);
        }

        private static void ApplyTransform(this SKCanvas canvas, Transform.ScaleOrigin transformOperation)
        {
            canvas.Scale((float)transformOperation.X, (float)transformOperation.Y, (float)transformOperation.XOrigin, (float)transformOperation.YOrigin);
        }

        private static void ApplyTransform(this SKCanvas canvas, Transform.ScaleRelativeOrigin transformOperation)
        {
            canvas.Scale((float)transformOperation.X, (float)transformOperation.Y, (float)transformOperation.XOffset * canvas.LocalClipBounds.Width, (float)transformOperation.YOffset * canvas.LocalClipBounds.Height);
        }
    }
}
